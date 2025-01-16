﻿global using System.Net.Http.Json;
global using System.Reflection;
global using BloodDonationManagement.Application.BackgroundServices;
global using BloodDonationManagement.Application.Behaviors;
global using BloodDonationManagement.Application.Dtos;
global using BloodDonationManagement.Application.Services;
global using BloodDonationManagement.Domain.Entities;
global using BloodDonationManagement.Domain.Enums;
global using BloodDonationManagement.Domain.Events;
global using BloodDonationManagement.Domain.Messages;
global using BloodDonationManagement.Domain.Repositories;
global using BloodDonationManagement.Domain.ValueObjects;
global using BloodDonationManagement.Infrastructure.AuthorizationAndAuthentication.Services;
global using FluentValidation;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;