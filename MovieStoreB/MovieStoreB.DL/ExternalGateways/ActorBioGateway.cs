using MovieStoreB.Models.DTO;
using MovieStoreB.Models.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreB.DL.ExternalGateways
{
    internal class ActorBioGateway : IActorBioGateway
    {
        public ActorBioGateway() {
            var options = new RestClientOptions("https://localhost:7077/ActorData/GetBioByActorId");
        
            _client = new RestClient(options);
        }

        private readonly RestClient _client;
        Task<ActorBioResponse> IActorBioGateway.GetBioByActor(Actor actorId)
        {
            return Task.FromResult(new ActorBioResponse
            {
                Summary = "Test"
            });
        }

        async Task<ActorBioResponse> IActorBioGateway.GetBioByActorId(string actorId)
        {
            var request = new RestRequest("/actorId/{id}", Method.Get);
            var response = await _client.GetAsync<ActorBioResponse>(request);

            return response;
        }
    }
}
