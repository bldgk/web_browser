#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace WB::JSCore;

namespace WB {
	namespace JSCore {

		class JSCoreMarshal
		{
		private:

			JSCoreMarshal() {}

		public:

			static JSStringRef StringToJSString(String ^ value);
			static String ^ JSStringToString(JSStringRef string);

		};

	}
} // namespace JSCore / namespace JSCore