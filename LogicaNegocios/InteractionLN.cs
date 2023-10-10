using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
     public class InteractionLN
    {
        private readonly InteractionService _interactionRepository;

        public InteractionLN(InteractionService interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task<List<Interaction>> GetInteractionsAsync()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return await _interactionRepository.GetAsync();
        }



    }
}
