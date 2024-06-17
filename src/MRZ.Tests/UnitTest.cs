using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MRZ.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDocumentTD1_Success()
        {
            var doc = new Document(
@"I<UTOD231458907<<<<<<<<<<<<<<<
7408122F1204159UTO<<<<<<<<<<<6
ERIKSSON<<ANNA<MARIA<<<<<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD1, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "I", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "UTO", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "D23145890", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1974, 8, 12), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(2012, 4, 15), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "UTO", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.OptionalData2, expected: "", message: "Wrong document optional data 2");
            Assert.AreEqual(actual: doc.Surname, expected: "ERIKSSON", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "ANNA MARIA", message: "Wrong name");

            doc = new Document(
@"I<PRT000024759<ZZ72<<<<<<<<<<<
8010100F2006017PRT<<<<<<<<<<<8
CARLOS<MONTEIRO<<AMELIA<VANESS");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD1, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "I", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "PRT", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "000024759", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "ZZ72", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1980, 10, 10), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(2020, 6, 1), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "PRT", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.OptionalData2, expected: "", message: "Wrong document optional data 2");
            Assert.AreEqual(actual: doc.Surname, expected: "CARLOS MONTEIRO", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "AMELIA VANESS", message: "Wrong name");

            doc = new Document(
@"IPUSAC030049646<<10<30<B22<498
8101017M1911297USA<<0754052296
TRAVELER<<HAPPY<<<<<<<<<<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD1, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "IP", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "USA", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "C03004964", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "<<10<30<B22<498", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1981, 01, 01), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'M', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(2019, 11, 29), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "USA", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.OptionalData2, expected: "<<075405229", message: "Wrong document optional data 2");
            Assert.AreEqual(actual: doc.Surname, expected: "TRAVELER", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "HAPPY", message: "Wrong name");

            // Taken from https://github.com/snifter/MRZCode.NET/commit/b6da286b16a1423f495615ecab6ec423c368e51c
            // Test for no expiry date (Moldavian ID Card for seniors)
            doc = new Document(
@"I<UTOD231458907<<<<<<<<<<<<<<<
7408122F<<<<<<0UTO<<<<<<<<<<<6
ERIKSSON<<ANNA<MARIA<<<<<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD1, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "I", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "UTO", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "D23145890", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1974, 8, 12), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: null, message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "UTO", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.OptionalData2, expected: "", message: "Wrong document optional data 2");
            Assert.AreEqual(actual: doc.Surname, expected: "ERIKSSON", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "ANNA MARIA", message: "Wrong name");

            // Test ExpirationDate correction when compared to BirthDate
            doc = new Document(
@"I<PRT000024759<ZZ72<<<<<<<<<<<
8010100F7006012PRT<<<<<<<<<<<8
CARLOS<MONTEIRO<<AMELIA<VANESS");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD1, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "I", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "PRT", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "000024759", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "ZZ72", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1980, 10, 10), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(2070, 6, 1), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "PRT", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.OptionalData2, expected: "", message: "Wrong document optional data 2");
            Assert.AreEqual(actual: doc.Surname, expected: "CARLOS MONTEIRO", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "AMELIA VANESS", message: "Wrong name");
        }

        [TestMethod]
        [DataRow(
@"I<UTOD231458907<<<<<<<<<<<<<<<
7408122F1204159UTO<<<<<<<<<<<6
ERIKSSON<<ANNA<MARIA<<<<<<<<<<")]
        [DataRow(
@"I<PRT000024759<ZZ72<<<<<<<<<<<
8010100F2006017PRT<<<<<<<<<<<8
CARLOS<MONTEIRO<<AMELIA<VANESS")]
        [DataRow(
@"IPUSAC030049646<<10<30<B22<498
8101017M1911297USA<<0754052296
TRAVELER<<HAPPY<<<<<<<<<<<<<<<")]
        [DataRow(
@"I<UTOD231458907<<<<<<<<<<<<<<<
7408122F<<<<<<0UTO<<<<<<<<<<<6
ERIKSSON<<ANNA<MARIA<<<<<<<<<<")]
        public void TestDocumentTD1_Failure(string mrz)
        {
            TestVariationsThrow(mrz, '|', MrzFormat.TD1);
        }

        [TestMethod]
        public void TestDocumentTD2_Success()
        {
            var doc = new Document(
@"I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<
D231458907UTO7408122F1204159<<<<<<<6");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD2, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "I", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "UTO", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "D23145890", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1974, 8, 12), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(2012, 4, 15), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "UTO", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.Surname, expected: "ERIKSSON", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "ANNA MARIA", message: "Wrong name");
        }

        [TestMethod]
        public void TestDocumentTD2_Failure()
        {
            Assert.ThrowsException<FormatException>(() => new Document(
@"I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<
D23145890<UTO7408122F1204159<<<<<<<6"), "'<' is not allowed as document number check digit");

            TestVariationsThrow(
@"I<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<
D231458907UTO7408122F1204159<<<<<<<6", '|', MrzFormat.TD2);
        }

        [TestMethod]
        public void TestDocumentTD3_Success()
        {
            var doc = new Document(
@"P<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<
L898902C36UTO7408122F1204159ZE184226B<<<<<10");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.TD3, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "P", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "UTO", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "L898902C3", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "ZE184226B", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1974, 8, 12), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(2012, 4, 15), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "UTO", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.Surname, expected: "ERIKSSON", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "ANNA MARIA", message: "Wrong name");
        }

        [TestMethod]
        public void TestDocumentTD3_Failure()
        {
            TestVariationsThrow(
@"P<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<
L898902C36UTO7408122F1204159ZE184226B<<<<<10", '|', MrzFormat.TD3);
        }

        [TestMethod]
        public void TestDocumentMRVA_Success()
        {
            var doc = new Document(
@"V<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<
L8988901C4XXX4009078F96121096ZE184226B<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.MRVA, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "V", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "UTO", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "L8988901C", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "6ZE184226B", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1940, 9, 7), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(1996, 12, 10), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "XXX", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.Surname, expected: "ERIKSSON", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "ANNA MARIA", message: "Wrong name");
        }

        [TestMethod]
        public void TestDocumentMRVA_Failure()
        {
            TestVariationsThrow(
@"V<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<
L8988901C4XXX4009078F96121096ZE184226B<<<<<<", '|', MrzFormat.MRVA);
        }

        [TestMethod]
        public void TestDocumentMRVB_Success()
        {
            var doc = new Document(
@"V<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<
L8988901C4XXX4009078F9612109<<<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.MRVB, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "V", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "UTO", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "L8988901C", message: "Wrong document number");
            Assert.AreEqual(actual: doc.OptionalData1, expected: "", message: "Wrong document optional data 1");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1940, 9, 7), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: new DateTime(1996, 12, 10), message: "Wrong expiration date");
            Assert.AreEqual(actual: doc.Nationality, expected: "XXX", message: "Wrong nationality country code");
            Assert.AreEqual(actual: doc.Surname, expected: "ERIKSSON", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "ANNA MARIA", message: "Wrong name");
        }

        [TestMethod]
        public void TestDocumentMRVB_Failure()
        {
            TestVariationsThrow(
@"V<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<
L8988901C4XXX4009078F9612109<<<<<<<<", '|', MrzFormat.MRVB);
        }

        [TestMethod]
        public void TestDocumentIDFRA_Success()
        {
            var doc = new Document(
@"IDFRALOISEAU<<<<<<<<<<<<<<<<<<<<<<<<
970675K002774HERVE<<DJAMEL<7303216M4");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.IDFRA, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "ID", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "FRA", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "970675K00277", message: "Wrong document number");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1973, 3, 21), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: null, message: "IDFRA does not contain an expiration date");
            Assert.AreEqual(actual: doc.Gender, expected: 'M', message: "Wrong gender");
            Assert.AreEqual(actual: doc.Nationality, expected: "", message: "IDFRA does not contain nationality information");
            Assert.AreEqual(actual: doc.Surname, expected: "LOISEAU", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "HERVE, DJAMEL", message: "Wrong name");

            doc = new Document(
@"IDFRADOUEL<<<<<<<<<<<<<<<<<<<<932013
0506932020438CHRISTIANE<<NI2906209F3");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.IDFRA, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "ID", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "FRA", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "050693202043", message: "Wrong document number");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1929, 6, 20), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: null, message: "IDFRA does not contain an expiration date");
            Assert.AreEqual(actual: doc.Gender, expected: 'F', message: "Wrong gender");
            Assert.AreEqual(actual: doc.Nationality, expected: "", message: "IDFRA does not contain nationality information");
            Assert.AreEqual(actual: doc.Surname, expected: "DOUEL", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "CHRISTIANE, NI", message: "Wrong name");
        }

        [TestMethod]
        [DataRow(
@"IDFRALOISEAU<<<<<<<<<<<<<<<<<<<<<<<<
970675K002774HERVE<<DJAMEL<7303216M4")]
        [DataRow(
@"IDFRADOUEL<<<<<<<<<<<<<<<<<<<<932013
0506932020438CHRISTIANE<<NI2906209F3")]
        public void TestDocumentIDFRA_Failure(string mrz)
        {
            TestVariationsThrow(mrz, '|', MrzFormat.IDFRA);
        }

        [TestMethod]
        public void TestDocumentSDL_Success()
        {
            var doc = new Document(
@"CTD718D<<
FACHE123456788001<<800126<<<<<
MARCHAND<<FABIENNE<<<<<<<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.SDL, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "FA", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "CHE", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "123456788001", message: "Wrong document number");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1980, 1, 26), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: null, message: "SDL does not contain an expiration date");
            Assert.AreEqual(actual: doc.Gender, expected: default, message: "SDL does not contain gender information");
            Assert.AreEqual(actual: doc.Nationality, expected: "", message: "SDL does not contain nationality information");
            Assert.AreEqual(actual: doc.Surname, expected: "MARCHAND", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "FABIENNE", message: "Wrong name");

            doc = new Document(
@"ABC123D<<
FACHE123456789001<<410624<<<<<
HUBER<<PETER<FRANZ<XAVER<<<<<<");

            Assert.AreEqual(actual: doc.DocumentFormat, expected: MrzFormat.SDL, message: "Wrong document format");
            Assert.AreEqual(actual: doc.DocumentType, expected: "FA", message: "Wrong document type");
            Assert.AreEqual(actual: doc.IssuingState, expected: "CHE", message: "Wrong document issuing state");
            Assert.AreEqual(actual: doc.DocumentNumber, expected: "123456789001", message: "Wrong document number");
            Assert.AreEqual(actual: doc.BirthDate, expected: new DateTime(1941, 6, 24), message: "Wrong birth date");
            Assert.AreEqual(actual: doc.ExpirationDate, expected: null, message: "SDL does not contain an expiration date");
            Assert.AreEqual(actual: doc.Gender, expected: default, message: "SDL does not contain gender information");
            Assert.AreEqual(actual: doc.Nationality, expected: "", message: "SDL does not contain nationality information");
            Assert.AreEqual(actual: doc.Surname, expected: "HUBER", message: "Wrong surname");
            Assert.AreEqual(actual: doc.Name, expected: "PETER FRANZ XAVER", message: "Wrong name");
        }

        [TestMethod]
        [DataRow(
@"CTD718D<<
FACHE123456788001<<800126<<<<<
MARCHAND<<FABIENNE<<<<<<<<<<<<")]
        [DataRow(
@"ABC123D<<
FACHE123456789001<<410624<<<<<
HUBER<<PETER<FRANZ<XAVER<<<<<<")]
        public void TestDocumentSDL_Failure(string mrz)
        {
            TestVariationsThrow(mrz, '|', MrzFormat.SDL);
        }

        private static void TestVariationsThrow(string mrz, char illegalChar, MrzFormat format)
        {
            int wrongOffset = 0;
            MrzFormat wrongFormat = MrzFormat.Unknown;

            switch (format)
            {
                case MrzFormat.MRVA:
                    wrongOffset = 1;
                    wrongFormat = MrzFormat.TD3;
                    break;
                case MrzFormat.MRVB:
                    wrongOffset = 1;
                    wrongFormat = MrzFormat.TD2;
                    break;
                case MrzFormat.IDFRA:
                    wrongOffset = 5;
                    wrongFormat = MrzFormat.TD2;
                    break;
            }

            foreach (var (wrongMrz, charPos) in CreateVariations(mrz, illegalChar))
            {
                var ex = Assert.ThrowsException<FormatException>(() => new Document(wrongMrz), $"'{illegalChar}' should not be allowed at position {charPos}");
                MrzFormat detectedFormat = charPos > wrongOffset ? format : wrongFormat;
                Assert.AreEqual($"Invalid {detectedFormat} document format", ex.Message, "Thrown exception should be from an unsuccessful regex match");
            }
        }

        /// <summary>
        /// Generates an <see cref="IEnumerable{T}"/> which contains variations of the given <paramref name="mrz"/>
        /// where each variation has one character replaced with <paramref name="c"/>
        /// </summary>
        private static IEnumerable<(string wrongMrz, int charPos)> CreateVariations(string mrz, char c)
        {
            char[] mrzArr = mrz.ToCharArray();

            int controlCount = 0;

            for (int i = 0; i < mrz.Length; i++)
            {
                if (char.IsControl(mrz[i]))
                {
                    controlCount++;
                    continue;
                }

                mrzArr[i] = c;
                yield return (new(mrzArr), i + 1 - controlCount);
                mrzArr[i] = mrz[i];
            }
        }
    }
}
