using Savage.Core.SourceCodeModeling.Structure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Savage.Core.SourceCodeModeling.Handlers
{
	internal class Parser
	{

		//parser 
		Regex declnameMatch = new Regex(@"[a-zA-Z][-_.a-zA-Z0-9]*\s*");
		Regex declareStringLit = new Regex(@"('[^']*\'|""[^""]*"")\s*");
		Regex markedSectionClose = new Regex(@"]\s*]\s*>");
		Regex msMarkedSectionClose = new Regex(@"]\s*>");

		//html parser
		Regex interestingNormal = new Regex("[<]");
		Regex interestingCData = new Regex(@"<(/|\Z)");

		Regex startTagOpen = new Regex("<[a-zA-Z]");
		Regex processingInstructionClose = new Regex(">");
		Regex commentClose = new Regex(@"--\s*>");
		Regex tagFind = new Regex("[a-zA-Z][-.a-zA-Z0-9:_]*");
		Regex attributeFind = new Regex(@"\s*([a-zA-Z_][-.:a-zA-Z_0-9]*)(\s*=\s*('[^']*'|""[^""]*""|" +
			@"[-a-zA-Z0-9./,:;+*%?!&$\(\)_#=~@]*))?");

		Regex locateStartTagEnd = new Regex(@"<[a-zA-Z][-.a-zA-Z0-9:_]*(?:\s+(?:[a-zA-Z_][-.:a-zA-Z0-9_]*(?:\s*=\s*(?:'[^']*'|\""[^\""]*\""|[^'\"">\s]+))?))*\s*");
		Regex endEndTag = new Regex(">");
		Regex endTagFind = new Regex(@"</\s*([a-zA-Z][-.a-zA-Z0-9:_]*)\s*>");

		Regex interesting;

		char[] otherChars = { };
		string[] preserveWhitespaceTags = { "pre", "textarea" };
		string SourceCode
		{
			get; set;
		} = string.Empty;
		string ContentType
		{
			get;
			set;
		}
        string lastTag;

        int lineNumber = 1;
        int offset;
        Tag currentTag
		{
			get;
			set;
		}
        Tag Root
		{
			get;
			set;
		}
        List<string> currentData = new List<string>();

        Stack<Tag> TagStack = new Stack<Tag>();

        string[] CDataContentElements = { "script", "style" };
        Dictionary<string, string> quoteTags = new Dictionary<string, string>()
        {
            { "script",   null },
            { "textarea", null }
        };

        Stack<string> quoteStack = new Stack<string>();

        public Parser()
        {
            interesting = interestingNormal;
            Root = Tag.Create("Savage.Core.SourceCodeModeling.Structure.Root");
            PushTag(Root);
        }

		public Root Parse(string src)
		{
			src = src.HtmlDecode();
			src = Regex.Replace(src, "\r|\n|\t", String.Empty);
			Feed(src);
			return (Root)Root;
		}


        void Feed(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
            }
            SourceCode += data;
            GoAhead();
            EndData();
            while (TagStack.Count > 1)
            {
                PopTag();
            }
        }

        void SetCDataMode(bool value)
        {
            if (value)
            {
                interesting = interestingCData;
            }
            else
            {
                interesting = interestingNormal;
            }
        }

        void GoAhead()
        {
            int i = 0;
            int j;
            int k;
            Match match;
            while (i < SourceCode.Length)
            {
                match = interesting.Match(SourceCode, i);
                if (match.Success)
                {
                    j = match.Index;
                }
                else
                {
                    j = SourceCode.Length;
                }
                if (i < j)
                {
                    HandleData(SourceCode.Substring(i, j - i));
                }
                i = UpdatePosition(i, j);
                if (i == SourceCode.Length)
                {
                    break;
                }
                if (SourceCode[i] == '<')
                {
                    if (startTagOpen.MatchAtIndex(SourceCode, i).Success)
                    {
                        k = ParseStartTag(i);
                    }
                    else if (SourceCode.Substring(i, 2) == "</")
                    {
                        k = ParseEndTag(i);
                    }
                    else if (SourceCode.Substring(i, 2) == "<!")
                    {
                        k = ParseDeclaration(i);
                    }
                    else if (i + 1 < SourceCode.Length)
                    {
                        HandleData("<");
                        k = i + 1;
                    }
                    else
                    {
                        break;
                    }
                    if (k < 0)
                    {
                        break;
                    }
                    i = UpdatePosition(i, k);
                }
            }
            SourceCode = SourceCode.Substring(i);
        }

        int RealParseDeclaration(int i)
        {
            int j = i + 2;
            string decltype;

            if (j >= SourceCode.Length || SourceCode[j] == '-')
            {
                return -1;
            }
            if (SourceCode[j] == '>')
            {
                return j + 1;
            }
            else if (SourceCode[j] == '[')
            {
                return ParseMarkedSection(i);
            }
            else
            {
                KeyValuePair<string, int> both = ScanName(j, i);
                decltype = both.Key;
                j = both.Value;
            }
            if (j < 0)
            {
                return j;
            }
            if (decltype == "doctype")
            {
                otherChars = new char[0];
            }
            while (j < SourceCode.Length)
            {
                char c = SourceCode[j];
                if (c == '>')
                {
                    string data = SourceCode.Substring(i + 2, j - (i + 2));
                    if (decltype == "doctype")
                    {
                        HandleDeclaration(data);
                    }
                    return j + 1;
                }
                if (c == '"' || c == '\'')
                {
                    Match m = declareStringLit.MatchAtIndex(SourceCode, j);
                    if (!m.Success)
                    {
                        return -1;
                    }
                    j = j + m.Length;
                }
                else if (Char.IsLetter(c))
                {
                    KeyValuePair<string, int> both = ScanName(j, i);
                    j = both.Value;
                }
                else if (otherChars.Contains(c))
                {
                    j += 1;
                }
                else if (c == '[')
                {
                    if (decltype == "doctype")
                    {
                        j = ParseDoctypeSubset(j + 1, i);
                    }
                    else if (new[] { "attlist", "linktype", "link", "element" }.Contains(decltype))
                    {
                        throw new HtmlParseException("Unsupported [ char in declaration: " + decltype);
                    }
                    else
                    {
                        throw new HtmlParseException("Unexpected [ char in declaration");
                    }
                }
                else
                {
                    throw new HtmlParseException("Unexpected  char in declaration: " + SourceCode[j]);
                }
                if (j < 0)
                {
                    return j;
                }
            }
            return -1;
        }

        int ParseDeclaration(int i)
        {
            int j;
            if (SourceCode.Substring(i, i + 9) == "<![CDATA[")
            {
                int k = SourceCode.IndexOf("]]>", i, StringComparison.Ordinal);
                if (k == -1)
                {
                    k = SourceCode.Length;
                }
                string data = SourceCode.Substring(i + 9, k - (i + 9));
                j = k + 3;
                ToStringSubClass(data, new CharacterData());
            }
            else
            {
                try
                {
                    j = RealParseDeclaration(i);
                }
                catch
                {
                    string toHandle = SourceCode.Substring(i);
                    HandleData(toHandle);
                    j = i + toHandle.Length;
                }
            }
            return j;
        }

        int ParseDoctypeSubset(int i, int declstartpos)
        {
            int j = i;
            while (j < SourceCode.Length)
            {
                char c = SourceCode[j];
                if (c == '<')
                {
                    if (j + 2 >= SourceCode.Length)
                    {
                        return -1;
                    }
                    string s = SourceCode.Substring(j, 2);
                    if (s != "<!")
                    {
                        UpdatePosition(declstartpos, j + 1);
                        throw new HtmlParseException("Unexpected char in internal subset: " + s);
                    }
                    if (j + 2 == SourceCode.Length)
                    {
                        return -1;
                    }
                    if (j + 4 > SourceCode.Length)
                    {
                        return -1;
                    }
                    if (SourceCode.Substring(j, 4) == "<!--")
                    {
                        if (j < 0)
                        {
                            return j;
                        }
                        continue;
                    }
                    KeyValuePair<string, int> both = ScanName(j + 2, declstartpos);
                    string name = both.Key;
                    j = both.Value;
                    if (name == "element")
                    {
                        j = ParseDoctypeElement(j, declstartpos);
                    }
                    else if (name == "entity")
                    {
                        j = ParseDoctypeEntity(j, declstartpos);
                    }
                    else if (name == "notation")
                    {
                        j = ParseDoctypeNotation(j, declstartpos);
                    }
                    else if (name == "attlist")
                    {
                        j = ParseDoctypeAttlist(j, declstartpos);
                    }
                    else
                    {
                        UpdatePosition(declstartpos, j + 2);
                        throw new HtmlParseException("Unknown declaration in internal subset: " + name);
                    }
                    if (j < 0)
                    {
                        return j;
                    }
                }
                else if (c == '%')
                {
                    if (j + 1 == SourceCode.Length)
                    {
                        return -1;
                    }
                    KeyValuePair<string, int> both = ScanName(j + 1, declstartpos);
                    string s = both.Key;
                    j = both.Value;
                    if (j < 0)
                    {
                        return j;
                    }
                    if (SourceCode[j] == ';')
                    {
                        j += 1;
                    }
                }
                else if (c == ']')
                {
                    j += 1;
                    while (j < SourceCode.Length && char.IsWhiteSpace(SourceCode[j]))
                    {
                        j += 1;
                    }
                    if (j < SourceCode.Length)
                    {
                        if (SourceCode[j] == '>')
                        {
                            return j;
                        }
                        UpdatePosition(declstartpos, j);
                        throw new HtmlParseException("Unexpected char after internal subset");
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (char.IsWhiteSpace(c))
                {
                    j += 1;
                }
                else
                {
                    UpdatePosition(declstartpos, j);
                    throw new HtmlParseException("Unexpected char in internal subset: " + c);
                }
            }

            return -1;
        }

        int ParseDoctypeAttlist(int i, int declstartpos)
        {
            var both = ScanName(i, declstartpos);
            int j = both.Value;
            if (j >= SourceCode.Length)
            {
                return -1;
            }
            char c = SourceCode[j];
            if (c == '>')
            {
                return j + 1;
            }
            while (true)
            {
                both = ScanName(j, declstartpos);
                j = both.Value;
                if (j < 0)
                {
                    return j;
                }
                if (j >= SourceCode.Length)
                {
                    return -1;
                }
                c = SourceCode[j];
                if (c == '(')
                {
                    if (SourceCode.Substring(j).Contains(")"))
                    {
                        j = SourceCode.IndexOf(")", j, StringComparison.Ordinal) + 1;
                    }
                    else
                    {
                        return -1;
                    }
                    while (char.IsWhiteSpace(SourceCode, j))
                    {
                        j += 1;
                    }
                    if (j >= SourceCode.Length)
                    {
                        return -1;
                    }
                }
                else
                {
                    both = ScanName(j, declstartpos);
                    j = both.Value;
                }

                if (j >= SourceCode.Length)
                {
                    return -1;
                }
                c = SourceCode[j];
                if (c == '"' || c == '\'')
                {
                    Match m = declareStringLit.MatchAtIndex(SourceCode, j);
                    if (m.Success)
                    {
                        j = j + m.Length;
                    }
                    else
                    {
                        return -1;
                    }
                    c = SourceCode[j];
                    if (j >= SourceCode.Length)
                    {
                        return -1;
                    }
                }
                if (c == '#')
                {
                    if (SourceCode.Substring(j) == "#")
                    {
                        return -1;
                    }
                    both = ScanName(j + 1, declstartpos);
                    j = both.Value;
                    if (j < 0)
                    {
                        return -1;
                    }
                    if (j >= SourceCode.Length)
                    {
                        return -1;
                    }
                }
                if (c == '>')
                {
                    return j + 1;
                }
            }
        }

        int ParseDoctypeNotation(int i, int declstartpos)
        {
            var both = ScanName(i, declstartpos);
            int j = both.Value;
            char c;
            if (j < 0)
            {
                return -1;
            }
            while (true)
            {
                if (j >= SourceCode.Length)
                {
                    return -1;
                }
                c = SourceCode[j];
                if (c == '>')
                {
                    return j + 1;
                }
                if (c == '\'' || c == '"')
                {
                    Match m = declareStringLit.MatchAtIndex(SourceCode, j);
                    if (!m.Success)
                    {
                        return -1;
                    }
                    j = j + m.Length;
                }
                else
                {
                    both = ScanName(j, declstartpos);
                    j = both.Value;
                    if (j < 0)
                    {
                        return j;
                    }
                }
            }
        }

        int ParseDoctypeEntity(int i, int declstartpos)
        {
            char c;
            int j;
            if (SourceCode[i] == '%')
            {
                j = i + 1;
                while (true)
                {
                    if (j >= SourceCode.Length)
                    {
                        return -1;
                    }
                    if (char.IsWhiteSpace(SourceCode, j))
                    {
                        j += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                j = i;
            }

            var both = ScanName(j, declstartpos);
            j = both.Value;
            if (j < 0)
            {
                return -1;
            }
            while (true)
            {
                if (j >= SourceCode.Length)
                {
                    return -1;
                }
                c = SourceCode[j];
                if (c == '\'' || c == '"')
                {
                    Match m = declareStringLit.MatchAtIndex(SourceCode, j);
                    if (m.Success)
                    {
                        j = j + m.Length;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (c == '>')
                {
                    return j + 1;
                }
                else
                {
                    both = ScanName(j, declstartpos);
                    j = both.Value;
                    if (j < 0)
                    {
                        return j;
                    }
                }
            }
        }
        
        int ParseDoctypeElement(int i, int declstartpos)
        {
            var both = ScanName(i, declstartpos);
            int j = both.Value;
            if (j < 0)
            {
                return -1;
            }
            if (SourceCode.Substring(j).Contains('>'))
            {
                return SourceCode.IndexOf(">", j, StringComparison.Ordinal) + 1;
            }
            return -1;
        }

        void HandleDeclaration(string text)
        {
            ToStringSubClass(text, new Declaration());
        }

        KeyValuePair<string, int> ScanName(int i, int declstartpos)
        {
            if (i == SourceCode.Length)
            {
                return new KeyValuePair<string, int>(null, -1);
            }
            Match m = declnameMatch.MatchAtIndex(SourceCode, i);
            if (m.Success)
            {
                string s = m.Groups[0].Value;
                string name = s.Trim();
                if (i + s.Length == SourceCode.Length)
                {
                    return new KeyValuePair<string, int>(null, -1);
                }
                return new KeyValuePair<string, int>(name.ToLowerInvariant(), i + m.Length);
            }
            else
            {
                UpdatePosition(declstartpos, i);
                throw new HtmlParseException("Expected name token.");
            }
        }

        int UpdatePosition(int i, int j)
        {
            if (i >= j)
            {
                return j;
            }
            int nlines = SourceCode.Substring(i, j - i).Count(c => c == '\n');
            if (nlines > 0)
            {
                lineNumber += nlines;
                int pos = SourceCode.LastIndexOf('\n', j - 1, j - i);
                offset = j - (pos + 1);
            }
            else
            {
                offset += j - i;
            }
            return j;
        }

        int ParseMarkedSection(int i)
        {
            var both = ScanName(i + 3, i);
            string name = both.Key;
            int j = both.Value;
            if (j < 0)
            {
                return -1;
            }
            Match match;
            if (new[] { "temp", "cdata", "ignore", "unclude", "rcdata" }.Contains(name))
            {
                match = markedSectionClose.Match(SourceCode, i + 3);
            }
            else if (new[] { "if", "else", "endif" }.Contains(name))
            {
                match = msMarkedSectionClose.Match(SourceCode, i + 3);
            }
            else
            {
                throw new HtmlParseException("Unknown status keyword in marked section: " + SourceCode.Substring(i + 3, j - (i + 3)));
            }
            if (!match.Success)
            {
                return -1;
            }
            j = match.Index;
            return match.Index + match.Length;
        }


        void ToStringSubClass(string text, Text p)
        {
            EndData();
            HandleData(text);
            EndData(p);
        }

        void HandleData(string data)
        {
            currentData.Add(data);
        }

        int ParseStartTag(int i)
        {
            int endPos = CheckForWholeStartTag(i);
            if (endPos < 0)
            {
                return endPos;
            }
            string starttagText = SourceCode.Substring(i, endPos - i);

            Match match = tagFind.MatchAtIndex(SourceCode, i + 1);
            int k = i + 1 + match.Length;
            lastTag = SourceCode.Substring(i + 1, k - (i + 1)).ToLowerInvariant();

			List<Savage.Core.SourceCodeModeling.Structure.TagAttribute> attributes = new List<Savage.Core.SourceCodeModeling.Structure.TagAttribute>();

            while (k < endPos)
            {
                match = attributeFind.MatchAtIndex(SourceCode, k);
                if (!match.Success)
                {
                    break;
                }
                string attributeName = match.Groups[1].Value;
                string rest = match.Groups[2].Value;
                string attributeValue = match.Groups[3].Value;
                if (string.IsNullOrEmpty(rest))
                {
                    attributeValue = null;
                }
                else if ((attributeValue[0] == '\'' && attributeValue[attributeValue.Length - 1] == '\'') ||
                        attributeValue[0] == '"' && attributeValue[attributeValue.Length - 1] == '"')
                {
                    attributeValue = attributeValue.Substring(1, attributeValue.Length - 2);
                }
                attributes.Add(new Savage.Core.SourceCodeModeling.Structure.TagAttribute(attributeName, attributeValue));
                k = k + match.Length;
            }

            Tag tag = Tag.Create("Savage.Core.SourceCodeModeling.Structure.HtmlTags." + lastTag, attributes) as Tag;

			string end = SourceCode.Substring(k, endPos - k).Trim();
            if (end != ">" && end != "/>")
            {
                var both = GetPosition();
                int lineNo = both.Key;
                int off = both.Value;
                if (starttagText.Contains('\n'))
                {
                    lineNo = lineNo + starttagText.Count(x => x == '\n');
                    off = starttagText.Length - starttagText.LastIndexOf('\n');
                }
                else
                {
                    off = off + starttagText.Length;
                }
                throw new HtmlParseException("Junk characters in start tag: " + starttagText);
            }
            if (end.EndsWith("/>", StringComparison.Ordinal))
            {
                HandleStartEndTag(tag);
            }
            else
            {
                HandleStartTag(tag);
                if (CDataContentElements.Contains(tag.TagName))
                {
                    SetCDataMode(true);
                }
            }

            return endPos;
        }

        void HandleStartEndTag(Tag tag)
        {
            HandleStartTag(tag);
            HandleEndTag(tag.TagName);
        }

        KeyValuePair<int, int> GetPosition()
        {
            return new KeyValuePair<int, int>(lineNumber, offset);
        }

        int CheckForWholeStartTag(int i)
        {
            Match m = locateStartTagEnd.MatchAtIndex(SourceCode, i);
            if (m.Success)
            {
                int j = i + m.Length;
                if (j >= SourceCode.Length)
                {
                    return -1;
                }
                char next = SourceCode[j];
                if (next == '>')
                {
                    return j + 1;
                }
                if (next == '/')
                {
                    if (SourceCode.Substring(j, 2) == "/>")
                    {
                        return j + 2;
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (char.IsLetter(next) || next == '=' || next == '/')
                {
                    return -1;
                }
                UpdatePosition(i, j);
                throw new HtmlParseException("Malformed start tag");
            }
            throw new HtmlParseException("Invalid call");
        }

        int ParseEndTag(int i)
        {
            Match match = endEndTag.Match(SourceCode, i + 1);
            if (!match.Success)
            {
                return -1;
            }
            int j = match.Index + match.Length;
            match = endTagFind.MatchAtIndex(SourceCode, i);
            if (!match.Success)
            {
                throw new HtmlParseException("Bad end tag.");
            }

            string tag = match.Groups[1].Value;
            HandleEndTag(tag.ToLowerInvariant());
            SetCDataMode(false);
            return j;
        }



        void HandleStartTag(Tag tag)
        {
            if (quoteStack.Count > 0)
            {
                string attrs = string.Empty;
                foreach (var attrib in tag.Attributes)
                {
                    attrs += string.Format(CultureInfo.InvariantCulture, " {0}=\"{1}\"", attrib.Name, attrib.Value);
                }
                HandleData(string.Format(CultureInfo.InvariantCulture, "<{0}{1}>", tag.TagName, attrs));
            }
            if (!tag.IsSelfClosing)
            {
                SmartPop(tag);
            }
            tag.Parent = currentTag;
            tag.Previous = Root.Previous;
            if (Root.Previous != null)
            {
                Root.Previous.Next = tag;
            }
            Root.Previous = tag;
            PushTag(tag);
            if (tag.IsSelfClosing)
            {
                PopTag();
            }
            if (quoteTags.ContainsKey(tag.TagName))
            {
                quoteStack.Push(tag.TagName);
            }
        }

        Tag PopTag()
        {
            TagStack.Pop();
            if (TagStack.Count > 0)
            {
                currentTag = TagStack.Peek();
            }
            return currentTag;
        }

        void PushTag(Tag tag)
        {
            if (currentTag != null)
            {
                currentTag.AddChild(tag);
            }
            TagStack.Push(tag);
            currentTag = TagStack.Peek();
        }

        void SmartPop(Tag tag)
        {
            //"""We need to pop up to the previous tag of this type, unless
            //one of this tag's nesting reset triggers comes between this
            //tag and the previous tag of this type, OR unless this tag is a
            //generic nesting trigger and another generic nesting trigger
            //comes between this tag and the previous tag of this type.

            //Examples:
            // <p>Foo<b>Bar *<p>* should pop to 'p', not 'b'.
            // <p>Foo<table>Bar *<p>* should pop to 'table', not 'p'.
            // <p>Foo<table><tr>Bar *<p>* should pop to 'tr', not 'p'.

            // <li><ul><li> *<li>* should pop to 'ul', not the first 'li'.
            // <tr><table><tr> *<tr>* should pop to 'table', not the first 'tr'
            // <td><tr><td> *<td>* should pop to 'tr', not the first 'td'
            //"""

            IAllowsNestingSelf nestableTag = tag as IAllowsNestingSelf;
            Tag popTo = null;
            bool inclusive = true;
            foreach (Tag t in TagStack)
            {
                if (t.TagName == tag.TagName && nestableTag == null)
                {
                    popTo = tag;
                    break;
                }
                else if (nestableTag != null && nestableTag.NestingBreakers.Contains(t.GetType()) ||
                    (nestableTag == null && tag.ResetsNesting && t.ResetsNesting))
                {
                    popTo = t;
                    inclusive = false;
                    break;
                }
            }
            if (popTo != null)
            {
                PopToTag(popTo.TagName, inclusive);
            }
        }

        void PopToTag(string popTo)
        {
            PopToTag(popTo, true);
        }

        void EndData(Text containerClass)
        {
            if (currentData.Count > 0)
            {
                string data = currentData.Aggregate(new StringBuilder(), (x, y) => x.Append(y)).ToString();
                
                char[] spaceChars = { (char)9, (char)10, (char)12, (char)13, (char)32 };
                if (string.IsNullOrEmpty(new string(data.Where(c => !spaceChars.Contains(c)).ToArray())))
                {
                    if (preserveWhitespaceTags.Intersect(TagStack.Select(tag => tag.TagName)).Count() == 0)
                    {
                        if (data.Contains("\n"))
                        {
                            data = "\n";
                        }
                        else
                        {
                            data = " ";
                        }
                    }
                }
                currentData = new List<string>();
                Text o = containerClass;
                o.Value = data;
                o.Setup(currentTag, Root.Previous);
                if (Root.Previous != null)
                {
                    Root.Previous.Next = o;
                }
                Root.Previous = o;
                currentTag.AddChild(o);
            }
        }

        void EndData()
        {
            EndData(new Text());
        }

        void HandleEndTag(string tag)
        {
            UnknownEndTag(tag);
        }

        void UnknownEndTag(string tag)
        {
            if (quoteStack.Count > 0 && quoteStack.Peek() != tag)
            {
                HandleData("</" + tag + ">");
                return;
            }
            EndData();
            PopToTag(tag);
            if (quoteStack.Count > 0 && quoteStack.Peek() == tag)
            {
                quoteStack.Pop();
            }
        }

        Tag PopToTag(string tag, bool inclusive)
        {
            if (tag == Root.TagName)
            {
                return null;
            }

            int numPops = 0;
            Tag mostRecentTag = null;
            int i = 0;
            foreach (Tag t in TagStack)
            {
                i++;
                if (tag == t.TagName)
                {
                    numPops = i;
                    break;
                }
            }
            if (!inclusive)
            {
                numPops -= 1;
            }
            for (int j = 0; j < numPops; j++)
            {
                mostRecentTag = PopTag();
            }
            return mostRecentTag;
        }
    }
}