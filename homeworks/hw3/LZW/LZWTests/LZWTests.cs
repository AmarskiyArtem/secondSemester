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

namespace LZWTests;

public class Tests
{
    private static IEnumerable<TestCaseData> Path()
    {
        yield return new TestCaseData(@"../../../TestFiles/HarryPotter.txt");
        yield return new TestCaseData(@"../../../TestFiles/NeverGonnaGiveUup.mp3");
        yield return new TestCaseData(@"../../../TestFiles/shad.jpg");
    }

    [TestCaseSource(nameof(Path))]
    public void EncodeAndDecodeShouldSame(string path)
    {
        var data = File.ReadAllBytes(path);
        byte[] dataCopy = new byte[data.Length];
        Array.Copy(data, dataCopy, data.Length);
        data = LZWEncoder.Encode(data, true);
        data = LZWDecoder.Decode(data);
        Assert.IsTrue(data.SequenceEqual(dataCopy));
    }

    [Test]
    public void TryingToEncodeNullShouldException()
    {
        Assert.Throws<ArgumentNullException>(() => LZWEncoder.Encode(null!, false)); // :)
    }

    [Test]
    public void TryingToDecodeNullShouldException()
    {
        Assert.Throws<ArgumentNullException>(() => LZWDecoder.Decode(null!));
    }

    [Test]
    public void TryingToEncodeEmptyShouldException()
    {
        Assert.Throws<ArgumentException>(() => LZWEncoder.Encode(new byte[0], true));
    }

    [Test]
    public void TryingToDecodeEmptyShouldException()
    {
        Assert.Throws<ArgumentException>(() => LZWDecoder.Decode(new byte[0]));
    }

    [Test]
    public void CompressNonExistentFileShouldExpection()
    {
        Assert.Throws<FileNotFoundException>(() => LZWTransform.Compress(@"../ghost.txt"));
    }

    [Test]
    public void DecompressNonExistentFileShouldExpection()
    {
        Assert.Throws<FileNotFoundException>(() => LZWTransform.Decompress(@"../../ghost.txt"));
    }

    [Test]
    public void DecompressNonZippedFileShouldExpection()
    {
        Assert.Throws<ArgumentException>(() => LZWTransform.Decompress(@"../../../TestFiles/HarryPotter.zip"));
    }
}