using SuperDog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample
{
    public class sample
    {
        
        string scope = "<dogscope />";
        public string main()
        {
            DogStatus status;
            //Dog curDog = new Dog(new DogFeature(DogFeature.FromFeature(EncryptedString1.EncryptBufFeatureID).Feature));

            Dog dd = new Dog();
            /************************************************************************
             * Login
             *   establishes a context for SuperDog
             */
            status = dd.Login("aFPNzVRNlOK8P1Jxx8lwjtmcGykauy04lEgpgUUmWMmWA7MI5IDl1fVVjdnwyTa8IdK5LdH1YR9pHods6WWoatpLKDiXzhlYCMRdB6y8lzSN0xH1ZCQblEJWN+hYoDk5kWuoqIVBaIclHLhvqq5nN/XH636zHJ5bLyPepyWkxlxluTXygmi2hbJl/1Isohtbm/KrcSjV/m3CUZJxFVJ+xItb9q6CEOjrHqdBcuD/YltVmq9Wnej8GB6048lsjuDQ5E+VHzOwDI+xfykferl4YEa6fA0onjq39mBpKjokqCkDPwxEacUvkmOGlheO1wdAtEDmCgOoCLEnC+IgCCaJV9At6n8aETRz0sYJ53fNEFWjeyp39Tr5zC3uxu1WJ+BDaHT+O2wd3okSB5zHJ/efaM14m2O7EtDOsUuImgrDvis0s/QO8ft/Ectf6j5wMsIDfOXMDvcRiLHygnQhDHieFnRN0jLlIwoFI+3DJcRRnwWH1xe3TfZKiqvDaujeCfgTZf5J15rIc1m2rT6ULYWmdZjnz0xfBC7tLfEDz64dxMdiw1pkS4AcBPnYbrEpSsg+tDPfwYfYq/Kr6n3pEiV4sVz/Nurqo5FrNYoB3SQJC2G3vRWN7zhrh2gLQVgFKd4sgAyAALNRs+kYIStHRcEePkxute14e2Pn97jTqrvi3XuYDRA1xXwK9+Aagdsf0qBqVxK7ar9OGGkOcxlgkRxTLlPOCGY7nmC9hS1JIVIXsDxjLwubp+u+lHj7SkDKDLK3Klzq4/rbng1WTrKQliTxjtwzDwpVCEMN7edAtKTRrZ6YVuovTk8DNLhsGrcIVuUx+9Wrn21l/b7YHvAqOzuQbH0+/WzrsFMsdgbuzTgFfe/Aomzu8NXVXcYa/I16bTnf6jvQQpul6TJSJcH4P9PSVq3ZgmdlHFteCKrQZW6+KB0m7s1dwiKCwnBgzojuWfiqiVsPoekAy3Ca6kSkO3frow==", scope);
            return status.ToString();
            //sample testSample = new sample();
            // decrypt string or raw data using SuperDog
            //return testSample.DecryptString().ToString();
        }
        //public DogStatus DecryptString()
        //{
        //    DogStatus status;
        //    UInt32 i = 0;
        //    byte[] bufData;
        //    byte[] strTmp;
        //    string strContents;

        //    Dog curDog = new Dog(new DogFeature(DogFeature.FromFeature(EncryptedString1.EncryptBufFeatureID).Feature));

        //    /************************************************************************
        //     * Login
        //     *   establishes a context for SuperDog
        //     */
        //    status = curDog.Login(VendorCode.strVendorCode, scope);
        //    if (status != DogStatus.StatusOk)
        //    {
        //        if (status == DogStatus.InvalidVendorCode)
        //        {
        //            Console.WriteLine("Invalid vendor code.\n");
        //        }
        //        else if (status == DogStatus.UnknownVcode)
        //        {
        //            Console.WriteLine("Vendor Code not recognized by API.\n");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Login to feature failed with status: " + status);
        //        }
        //        return status;
        //    }

        //    bufData = new byte[encrString1.EncryptBufLen];
        //    for (i = 0; i < encrString1.EncryptBufLen; ++i)
        //    {
        //        bufData[i] = encrString1.encryptStrArr[i];
        //    }

        //    // decrypt the data.
        //    // on success we convert the data back into a 
        //    // human readable string.
        //    status = curDog.Decrypt(bufData);
        //    if (DogStatus.StatusOk != status)
        //    {
        //        Console.WriteLine("Dog decrypt failed with status: " + status);
        //        curDog.Logout();
        //        return status;
        //    }

        //    //If source string length is less than 16, we need cut the needless buffer
        //    if (encrString1.EncryptBufLen > encrString1.SourceBufLen)
        //    {
        //        strTmp = new byte[encrString1.SourceBufLen];
        //        for (i = 0; i < encrString1.SourceBufLen; ++i)
        //        {
        //            strTmp[i] = bufData[i];
        //        }
        //        strContents = UTF8Encoding.UTF8.GetString(strTmp);
        //    }
        //    else
        //    {
        //        strContents = UTF8Encoding.UTF8.GetString(bufData);
        //    }

        //    //Use the decrypted string do some operation    
        //    if (0 == encrString1.isString)
        //    {
        //        DumpBytes(bufData, encrString1.SourceBufLen);
        //    }
        //    else
        //    {
        //        Console.WriteLine("The decrypted string is: \"" + strContents + "\".");
        //    }

        //    status = curDog.Logout();
        //    return status;
        //}
        protected void DumpBytes(byte[] bytes, int ilen)
        {
            Console.WriteLine("The decrypted buffer data is below :");
            int index = 0;

            for (index = 0; index < ilen; index++)
            {
                if (0 == (index % 8))
                {
                    if (0 == index)
                    {
                        Console.Write("          ");
                    }
                    else
                    {
                        Console.Write("\r\n          ");
                    }
                }
                Console.Write("0x" + bytes[index].ToString("X2") + " ");
            }
            Console.WriteLine("");
        }
    }
}
