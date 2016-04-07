using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Diagnostics;

namespace TestCaptcha
{
    
        class Program
        {
            static void Main(string[] args)
            {
                // Code usage sample
                Ocr ocr = new Ocr();
                using (Bitmap jpg = new Bitmap(@"C:\Users\migue\OneDrive\Documentos\Visual Studio 2015\Projects\TestCaptcha\avoid-captcha.jpg"))
                {
                    tessnet2.Tesseract tessocr = new tessnet2.Tesseract();
                    tessocr.Init(null, "eng", false);
                    tessocr.GetThresholdedImage(jpg, Rectangle.Empty).Save("c:\\temp\\" + Guid.NewGuid().ToString() + ".jpg");
                    // Tessdata directory must be in the directory than this exe
                    Console.WriteLine("Multithread version");
                    ocr.DoOCRMultiThred(jpg, "eng");
                    Console.WriteLine("Normal version");
                    ocr.DoOCRNormal(jpg, "eng");
                }
            }
        }

        public class Ocr
        {
            public void DumpResult(List<tessnet2.Word> result)
            {
            foreach (tessnet2.Word word in result) {
                Debug.WriteLine(word.Text);
                Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
            }
               
            }

            public List<tessnet2.Word> DoOCRNormal(Bitmap image, string lang)
            {
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.Init(null, lang, false);
                List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
                DumpResult(result);
                return result;
            }

            ManualResetEvent m_event;

            public void DoOCRMultiThred(Bitmap image, string lang)
            {
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.Init(null, lang, false);
                // If the OcrDone delegate is not null then this'll be the multithreaded version
                ocr.OcrDone = new tessnet2.Tesseract.OcrDoneHandler(Finished);
                // For event to work, must use the multithreaded version
                ocr.ProgressEvent += new tessnet2.Tesseract.ProgressHandler(ocr_ProgressEvent);
                m_event = new ManualResetEvent(false);
                ocr.DoOCR(image, Rectangle.Empty);
                // Wait here it's finished
                m_event.WaitOne();
            }

            public void Finished(List<tessnet2.Word> result)
            {
                DumpResult(result);
                m_event.Set();
            }

            void ocr_ProgressEvent(int percent)
            {
                Console.WriteLine("{0}% progression", percent);
            }
        }

    }

