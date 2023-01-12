using AutoMapper;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DTOs.Entities;
using User = MundoBalloonApi.infrastructure.Data.Models.User;

namespace MundoBalloonApi.graphql.Users;

[ExtendObjectType(Name = "Query")]
public partial class UserQueries
{
}