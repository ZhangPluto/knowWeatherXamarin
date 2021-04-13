//
// Sys.cs
//
// Author:
//       renhaozhang <lionelzhang99@gmail.com>
//
// Copyright (c) 2021 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Newtonsoft.Json;
namespace finalProject.model
{
    public class Sys
    {
        private int type;
        private int id;
        private string country;
        private long sunrise;
        private long sunset;

        [JsonProperty(PropertyName = "type")]
        public int Type { get => type; set => type = value; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get => id; set => id = value; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get => country; set => country = value; }
        [JsonProperty(PropertyName = "sunrise")]
        public long Sunrise { get => sunrise; set => sunrise = value; }
        [JsonProperty(PropertyName = "sunset")]
        public long Sunset { get => sunset; set => sunset = value; }
    }
}
