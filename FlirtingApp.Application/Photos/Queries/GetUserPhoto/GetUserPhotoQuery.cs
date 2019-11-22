﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlirtingApp.Application.Common.Interfaces.Databases;
using FlirtingApp.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlirtingApp.Application.Photos.Queries.GetUserPhoto
{
	public class GetUserPhotoQuery: IRequest<PhotoDto>
	{
		public Guid UserId { get; set; }
		public Guid PhotoId { get; set; }
	}

	public class GetUserPhotoQueryHandler : IRequestHandler<GetUserPhotoQuery, PhotoDto>
	{
		private readonly IAppDbContext _context;
		private readonly IMapper _mapper;

		public GetUserPhotoQueryHandler(IAppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<PhotoDto> Handle(GetUserPhotoQuery request, CancellationToken cancellationToken)
		{
			var user = await _context.Users
				.Include(u => u.Photos)
				.FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);
			if (user == null)
			{
				throw new ResourceNotFoundException("User", request.UserId);
			}

			var photo = user.GetPhoto(request.PhotoId);
			if (user == null)
			{
				throw new ResourceNotFoundException("Photo", request.PhotoId);
			}
			return _mapper.Map<PhotoDto>(photo);
		}
	}
}
