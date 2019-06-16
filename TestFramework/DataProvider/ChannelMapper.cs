using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TestFramework.DataProvider
{
    class ChannelMapper
    {
        private readonly static Dictionary<string, string> _channelMap = new Dictionary<string, string>
        {
            ["Desktop"] = "desktop_windows"
        };

        public static string ToMapChannel(string channel)
        {
            return _channelMap[channel];
        }
    }
}
