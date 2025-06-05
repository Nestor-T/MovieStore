using MovieStoreB.Models.DTO;
using MovieStoreB.Models.Responses;
using System;
using System.Data;
using System.Threading;
using RestSharp;

namespace MovieStoreB.DL.ExternalGateways
{
    public interface IActorBioGateway
    {
        public Task<ActorBioResponse> GetBioByActor(Actor actorId);


        public Task<ActorBioResponse> GetBioByActorId(string actorId); 

    }
}