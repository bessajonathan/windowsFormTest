using System;

namespace Desafio.Services
{
    public class Hash
    {
        public String BuildHash(String id)
        {
            var classHash = new HashTest.Hash();

            return classHash.BuildHash(id);
        }
    }
}
