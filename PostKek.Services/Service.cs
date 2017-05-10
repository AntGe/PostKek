using PostKek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Services
{
    public class Service
    {
        private PostKekContext context;

        protected Service()
        {
            this.context = new PostKekContext();
        }

        protected PostKekContext Context => this.context;
    }
} 
