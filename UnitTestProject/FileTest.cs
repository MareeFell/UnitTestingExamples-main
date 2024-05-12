﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTestEx;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;

        /* ПРОВАЙДЕР */
        public static IEnumerable<object[]> FilesData
        {
            get
            {
                return new[]
                {
                    new object[] { new File(FILE_PATH_STRING, CONTENT_STRING), FILE_PATH_STRING, CONTENT_STRING },
                    new object[] { new File(SPACE_STRING, SPACE_STRING), SPACE_STRING, SPACE_STRING }
                };
            }
        }

        /* Тестируем получение размера */
        [TestMethod]
        public void GetSizeTest()
        {
            File newfile = new File(FILE_PATH_STRING, CONTENT_STRING);
            String content = CONTENT_STRING;

            lenght = content.Length / 2;

            Assert.AreEqual(newfile.GetSize(), lenght, SIZE_EXCEPTION);
        }

        /* Тестируем получение имени */
        [TestMethod]
        [DynamicData(nameof(FilesData))]
        public void GetFilenameTest(File newFile, String name, String content)
        {
            Assert.AreEqual(newFile.GetFilename(), name, NAME_EXCEPTION);
        }

    }
}