using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace LogicaNegocios
{
    public class InteractionService
    {
        private readonly Dal.InteractionRepository _interactionRepository;

        public InteractionService(InteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task<List<Interaction>> GetInteractionsAsync()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return await _interactionRepository.GetAsync();
        }
        // string ip, string hora, string reaccion

        public async Task CreateInteractionAsync(InteractionDTo interactionDTo, string ip)
        {
            try
            {

                string hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string textColor = GenerarColorConRedesNeuronales();
                string contentColor = GenerarColorConRedesNeuronales();

                var interaction = new Interaction
                {
                    Ip = ip,
                    Hora = hora,
                    TextColor = textColor,
                    ContentColor = contentColor,
                    Reaccion = interactionDTo.Reaccion
                };

                await _interactionRepository.CreateAsync(interaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public async Task CreateInteractionAsync(string reaccion, string ip)
        {
            try
            {
            
                string hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string textColor = GenerarColorConRedesNeuronales();
                string contentColor = GenerarColorConRedesNeuronales();

                var interaction = new Interaction
                {
                    Ip = ip,
                    Hora = hora,
                    TextColor = textColor,
                    ContentColor = contentColor,
                    Reaccion = reaccion
                };

                await _interactionRepository.CreateAsync(interaction);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al guardar la interacción.
                // Puedes registrar el error o realizar cualquier otra acción necesaria.
                throw ex;
            }
        }
        */
        private string GenerarColorConRedesNeuronales()
        {
            // Lógica para generar un color utilizando redes neuronales
            // Puedes implementar aquí tu algoritmo de generación de colores
            // y devolver el color en un formato adecuado (por ejemplo, como un código hexadecimal).
            return "#FFAABB"; // Ejemplo de un color hexadecimal
        }

    }
}
