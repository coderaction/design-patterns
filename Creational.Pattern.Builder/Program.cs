using System;

namespace Creational.Pattern.Builder
{
    
    /// <summary>
    /// Çalışan Code: https://code.sololearn.com/cxKtzsiXDWUE
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Creational'dır bir pattern'dir
            //Creational bir nesnenin oluşmasını sağlayan patterndir.
            //Nesnelerin sırasıyla ve kontrollü oluşmasını yerine getirir. 
            //Base bir objemiz vardır base obje örneklendiğinde ve build alındığında , sırasıyla çalışmasını istediğimiz, methodlarımız bulunmaktadır. 
            
            //Örnek yapalım,
            //Benim 2 farklı class'ım olsun, 2 farklı class 'ım kendi içerisinde çok farklı işlemler yapsın ama
            //Günün sonunda 2 'class'ında ortak kullandıkları yapı log mekanızması olsun
            //1. İşlem:  Log'u db 'ye yazsın 
            //2. işlem : Log'u ELK'ya yazsın.

            var director = new Director();
            
            var firstClass = new FirstClass();
            director.Build(firstClass);
            
            //SON
            //Builder pattern ile Factory Pattern birbirleriyle birçok benzerlik gösterir. 
            //Peki Hangisini kullanmalıyım ?
            //Complex yapılarda Builder Pattern,
            //Tek bir obje için, factory veya abstract factory pattern 'i seçebilirsiniz.
        }
    }

    public class LogInfo
    {
        private string logClassName;
        
        public LogInfo(string logClassName )
        {
            this.logClassName = logClassName;
        }
    }

    /// <summary>
    /// LogBuilder Abstract Classs 'ı istediğim tüm class'lar da kullanabilmek için oluşturdum
    /// </summary>
    public abstract class LogBuilder
    {
        public abstract void Elk();
        public abstract void DbInsert();
        LogInfo LogInfo { get; }
    }
    
    /// <summary>
    /// 1. Class'a LogBuilder Inject ettim, ovveride ederek, methodlarını ezdim.
    /// </summary>
    public class FirstClass: LogBuilder
    {
        private LogInfo className;
        public FirstClass()
        {
            className=new LogInfo("ilk class'imiz");
        }
        public override void Elk()
        {
            Console.WriteLine("firstClass - elk'ya yazdiriliyor");
        }

        public override void DbInsert()
        {
            Console.WriteLine("firstClass - db'ye yazdiriliyor");
        }

        public LogInfo LogInfo
        {
            get { return className; }
        }
    }
    
    /// <summary>
    /// 2. Class'a LogBuilder Inject ettim, ovveride ederek, methodlarını ezdim.
    /// </summary>
    public class SecondClass: LogBuilder
    {
        private readonly LogInfo _className;
        public SecondClass()
        {
            _className=new LogInfo("ikinci Class'ımız");
        }
        public override void Elk()
        {
            Console.WriteLine("secondClass - yazdiriliyor");
        }

        public override void DbInsert()
        {
            Console.WriteLine("secondClass - db'ye yazdiriliyor");
        }

        public LogInfo LogInfo
        {
            get { return _className; }
        }
    }

    /// <summary>
    ///  //Nesnelerin sırasıyla ve kontrollü oluşmasını yerine getirir, dediğimiz yer tam da bu alan.
    /// Bu class'ımızda hangi log 'un önce atılacağını karar veriyorum.  
    /// </summary>
    public class Director
    {
        public void Build(LogBuilder logBuilder)
        {
            logBuilder.DbInsert();
            logBuilder.Elk();
        }
    }
}