using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
   public interface ICacheManager
    {//cache neler yapılır onlları yazıcaz

        T Get<T>(string key);//cache dğerini okumaya çalış

        object Get(string key);

        void Add(string key, object data, int duration);//cachei eklemk için 

        bool IsAdd(string key);

        void Remove(string key);// belli keydeki cachein ortadan kaldırılmasını sağlar

        void RemoveByPattern(string pattern);//patternle başlayan bütün cacheleri sil gibi yani get ile başlayan bütün cacheleri sil gibi
            



    }
}
