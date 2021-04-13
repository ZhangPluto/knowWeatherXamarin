//
// MainInfo.cs
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
    public class MainInfo
    {
        private double temp;
        private double feelsLike;
        private double tempMin;
        private double tempMax;
        private long pressure;
        private int humidity;

        [JsonProperty(PropertyName = "temp")]
        public double Temp { get => temp; set => temp = value; }
        [JsonProperty(PropertyName = "feels_like")]
        public double FeelsLike { get => feelsLike; set => feelsLike = value; }
        [JsonProperty(PropertyName = "temp_min")]
        public double TempMin { get => tempMin; set => tempMin = value; }
        [JsonProperty(PropertyName = "temp_max")]
        public double TempMax { get => tempMax; set => tempMax = value; }
        [JsonProperty(PropertyName = "pressure")]
        public long Pressure { get => pressure; set => pressure = value; }
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get => humidity; set => humidity = value; }
    }
}
