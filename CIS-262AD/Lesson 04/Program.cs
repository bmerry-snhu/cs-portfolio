using QRCodeLib;

namespace Lesson_04
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.Write("Enter the project site address: ");
            QRCodeGen qrCodeGen = new QRCodeGen(Console.ReadLine());
            return;
        }
    }
}