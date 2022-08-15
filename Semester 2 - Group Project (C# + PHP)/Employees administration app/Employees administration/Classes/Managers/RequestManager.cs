using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class RequestManager : IBasicFunctions<RestockRequest>
    {
        public List<RestockRequest> RestockRequests;
        private RestockRequestMediator requestMediator;

        public RequestManager()
        {
            this.RestockRequests = new List<RestockRequest>();
            this.requestMediator = new RestockRequestMediator();
        }

        public bool Add(RestockRequest request)
        {
            if (request != null)
            {
                this.RestockRequests.Add(request);
                this.requestMediator.Add(request);
                return true;
            }
            else { return false; }
        }

        public bool Remove(RestockRequest request)
        {
            //this.Load();
            if (this.Get(request.ID) != null)
            {
                this.RestockRequests.Remove(request);
                if (this.requestMediator.Remove(request))
                {
                    return true;
                }
                else { return false; }

            }
            else { return false; }
        }

        public RestockRequest Get(int id)
        {
            foreach (RestockRequest request in this.GetAll())
            {
                if (request.ID == id) { return request; }
            }
            return null;
        }

        public bool CheckRequestAlreadySent(RestockRequest request)
        {
            foreach (RestockRequest restockRequest in this.GetAll())
            {
                if (restockRequest.ProductId == request.ProductId) { return true; }
            }
            return false;

            //if (this.requestMediator.CheckRequestAlreadySent(request))
            //{
            //    return true;
            //}
            //else { return false; }
        }

        public List<RestockRequest> GetAll()
        {
            this.Load();
            return this.RestockRequests;
        }

        public bool Load()
        {
            this.RestockRequests = this.requestMediator.GetAll();
            if (this.RestockRequests != null)
            {
                return true;
            }
            else { return false; }
        }

    }
}
