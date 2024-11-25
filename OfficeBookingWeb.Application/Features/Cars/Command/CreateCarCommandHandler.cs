using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeBookingWeb.Application.Contracts.Persistence;
using OfficeBookingWeb.Domain.Entities;

namespace OfficeBookingWeb.Application.Features.Cars.Command
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }


        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);

            await _carRepository.AddAsync(car);

            return car.CarId;
        }
    }
}
