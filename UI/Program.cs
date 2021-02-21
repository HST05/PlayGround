using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ITissueService tissueService = new TissueManager(new TissueDal());
            foreach (var tissues in tissueService.GetDetail())
            {
                Console.WriteLine(tissues.Id + ":" + tissues.Name + "," + tissues.Type + "," + tissues.Region + "," + tissues.Origin);
            }

            Console.ReadLine();
        }
    }
}
