using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(long id);
        public Task<T> Add(T value);
        public Task<T> Edit(T value);
        public Task Delete(long id);
    }
}