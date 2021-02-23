using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ITissueService tissueService = new TissueManager(new TissueDal());

            foreach (var tissue in tissueService.GetDetail().Data)
            {
                Console.WriteLine(tissue.Id + ":" + tissue.Name + "," + tissue.Type + "," + tissue.Region + "," + tissue.Origin);
            }

            Console.ReadLine();
        }
    }
}
