using System;
using System.Collections.Generic;


/*

Application architecture                           External resources
------------------------------------------------------------------------------
Presentation                                   ||    Database servers,
---> Business Logic                            ||    Web APIs & Cloud services
[---> Business Data Layer] (skipped for now)   ||    Files etc.
---> Data Implementation layer               <----> 

*/

namespace Kata.DataServices
{
    public interface IDataService
    {
        T LoadDictionary<T>(string dictionarySource);
    }
}
