//
// MainWeather.cs
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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace finalProject.model
{
    public class MainWeather
    {
        
        private Coord coords;
        private Weather[] weathers;
        private string baseInfo;
        private MainInfo mainInfos;
        private long visibility;
        private Wind winds;
        private Clouds clouds;
        private long dateTime;
        private Sys sys;
        private long timeZone;
        private long id;
        private string name;
        private int cod;

        [JsonProperty(PropertyName ="coord")]
        public Coord Coords { get => coords; set => coords = value; }
        [JsonProperty(PropertyName = "weather")]
        public Weather[] Weathers { get => weathers; set => weathers = value; }
        [JsonProperty(PropertyName = "base")]
        public string BaseInfo { get => baseInfo; set => baseInfo = value; }
        [JsonProperty(PropertyName = "main")]
        public MainInfo MainInfos { get => mainInfos; set => mainInfos = value; }
        [JsonProperty(PropertyName = "visibility")]
        public long Visibility { get => visibility; set => visibility = value; }
        [JsonProperty(PropertyName = "wind")]
        public Wind Winds { get => winds; set => winds = value; }
        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get => clouds; set => clouds = value; }
        [JsonProperty(PropertyName = "dt")]
        public long DateTime { get => dateTime; set => dateTime = value; }
        [JsonProperty(PropertyName = "sys")]
        public Sys Sys { get => sys; set => sys = value; }
        [JsonProperty(PropertyName = "timezone")]
        public long TimeZone { get => timeZone; set => timeZone = value; }
        [JsonProperty(PropertyName = "id")]
        public long Id { get => id; set => id = value; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty(PropertyName = "cod")]
        public int Cod { get => cod; set => cod = value; }
        
    }
}
