/*
 * This file is part of project "Second Semester".
 * Copyright (c) [2023] [Artem Amarskiy].
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     https://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace BWTLibraryTests;

public class BWTTests
{
    [Test]
    public void DirectAndReverseConversionsShouldRightAnswer()
    {
        var original = "ABACABA";
        var (result, index) = BWTTransform.FastDirectConversion(original);
        Assert.That(original, Is.EqualTo(BWTTransform.ReverseConversion(result, index)));
    }

    [Test]
    public void EmptyStringShouldException()
    {
        Assert.Throws<ArgumentException>(() => BWTTransform.FastDirectConversion(String.Empty));
        Assert.Throws<ArgumentException>(() => BWTTransform.ReverseConversion(String.Empty, 0));
    }

    [Test]
    public void OnlyDirectShouldRightReturns()
    {
        var (result, index) = BWTTransform.FastDirectConversion("you want a different string instance");
        Assert.That(result, Is.EqualTo("tagtu twn rfcfindr aiiaeyetn nnsso e"));
        Assert.That(index, Is.EqualTo(35));
    }

    [Test]
    public void OnlyReverseShouldRightReturns()
    {
        var original = BWTTransform.ReverseConversion("a5* a4S6_ aaNnNb7 ", 16);
        Assert.That(original, Is.EqualTo("ba_Na * na45 NaS67"));
    }
}