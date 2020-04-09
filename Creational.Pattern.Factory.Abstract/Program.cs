using System;

namespace Creational.Pattern.Factory.Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Deneme<MercedesFactory> mercedesFactory = new Deneme<MercedesFactory>();
            mercedesFactory.Cars();
            
          
        }
    }

    public interface IF1RaceCar
    {
        string BrandName { get; set; }
        
        void AutoFuelDriving();
        void DynamicMode();
        void SuperChargerMode();
    }

    public interface IOffRoadCar
    {
        string BrandName { get; set; }
        
        void LandMode();
        void AwsMode();
        void HillDescentControl();
    }

    public interface ICarTypeFactory
    {
        IF1RaceCar CityCar();
        IOffRoadCar OffRoadCar();
    }
    
    public class DakarRally: IOffRoadCar
    {
        public string BrandName { get; set; }
        
        public void LandMode()
        {
           Console.WriteLine("Arazi Modu Devrede");
        }

        public void AwsMode()
        {
            Console.WriteLine("Yarı Zamanlı Arazi Modu Devrede ");
        }

        public void HillDescentControl()
        {
            Console.WriteLine("Yokuş İniş Destek Sistemi Devrede");
        }
    }
    
    public class MonocoGrandPrix:IF1RaceCar
    {
        public string BrandName { get; set; }


        public void AutoFuelDriving()
        {
            Console.WriteLine("Otomatik Yakıt Yol Sürüş Modu");
        }

        public void DynamicMode()
        {
            Console.WriteLine("Dinamik Mod");
        }

        public void SuperChargerMode()
        {
            Console.WriteLine("Super Şarj Turbo Mod");
        }
    }
    
    public class MercedesFactory:ICarTypeFactory
    {
        public IF1RaceCar CityCar()
        {
            MonocoGrandPrix monocoGrandPrix = new MonocoGrandPrix();
            monocoGrandPrix.BrandName = "Mercedes SLC Support";
            monocoGrandPrix.SuperChargerMode();
            return monocoGrandPrix;
        }

        public IOffRoadCar OffRoadCar()
        {
            DakarRally dakarRally = new DakarRally();
            dakarRally.BrandName = "Mercedes G Class";
            dakarRally.LandMode();
            return dakarRally;
        }
    }
    
    public class PorscheFactory:ICarTypeFactory
    {
        public IF1RaceCar CityCar()
        {
            MonocoGrandPrix monocoGrandPrix = new MonocoGrandPrix();
            monocoGrandPrix.BrandName = "Porsche 911 Carrera 4 Gts";
            monocoGrandPrix.DynamicMode();
            return monocoGrandPrix;
        }

        public IOffRoadCar OffRoadCar()
        {
            DakarRally dakarRally = new DakarRally();
            dakarRally.BrandName = "Porsche Cayanne Jeep";
            dakarRally.LandMode();
            return dakarRally;
        }
    }

    public class Deneme<T> where T : ICarTypeFactory, new()
    {
        private IF1RaceCar _f1RaceCar;
        private IOffRoadCar _offRoadCar;
        private T factory;

        public Deneme()
        {
            factory = new T();
            _f1RaceCar = factory.CityCar();
            _offRoadCar = factory.OffRoadCar();
        }

        public void Cars()
        {
            _f1RaceCar.DynamicMode();
           // _offRoadCar.LandMode();
        }
    }
}