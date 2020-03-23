using System;

namespace Creational.Pattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Creational Pattern
            //Bu tasarım deseni nesneleri doğrudan new operatörü kullanarak oluşturmak yerine nesne oluşturma mantığını
            //gizleyerek sınıflardan nesne oluşturmaya alternatif çözümler sunar. Bu program akışında hangi nesneye ihtiyaç varsa
            //onu oluşturmada esneklik ve kolaylık sağlar.
            
            //Singleton (tek nesne) tasarım kalıbı, bir sınıfın tek bir örneğini almak için kullanılır
            //Amaç oluşturulan nesneyi, global erişim noktası olarak sağlamaktır. 
            //Sistem çalıştığı müddetçe ikinci bir örnek oluşturulamaz.
            //Singleton nesneler ilk çağırıldıklarında bir kere oluşturulurlar ve sonraki istekler bu nesne üzerinden karşılanır.
            
            //6 Adet Yaklaşımı vardır, bunlar; 
            
            //Eager Initialization
            //Static Block Initialization
            //Lazy Initialization
            //Lazy Initialization ve Double Check Locking
            //Bill Pugh Singleton
            //Thread Safe Singleton
            
            Console.WriteLine("Hello World!");
            
            //Eager Initialization
            SingletonExampleEagerInitialization singletonExampleEagerInitialization = SingletonExampleEagerInitialization.getInstance();
            singletonExampleEagerInitialization.Log("Test");
        }
    }
    
    
      /// <summary>
      /// //Eager Initialization
      /// Kodun çalışır hali: https://code.sololearn.com/ccHMLd4id9tP
      /// </summary>
    public class SingletonExampleEagerInitialization {

        private static readonly SingletonExampleEagerInitialization instance = new SingletonExampleEagerInitialization();

        private SingletonExampleEagerInitialization()
        {
            
        }
        
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}]: {message }");
        }

        public static SingletonExampleEagerInitialization getInstance(){
            return instance;
        }
    }
}