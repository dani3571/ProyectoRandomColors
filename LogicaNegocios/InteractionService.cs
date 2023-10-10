using Dal;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateInteractionAsync(string ip, string hora, string reaccion)
        {
            try
            {
                // Generar colores con redes neuronales y asignarlos a TextColor y ContentColor
                string textColor = GenerarColorConRedesNeuronales();
                string contentColor = GenerarColorConRedesNeuronales();

                // Obtener la hora actual y convertirla a un formato deseado
          //      string hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Crear una nueva instancia de Interaction con los datos generados
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

        private string GenerarColorConRedesNeuronales()
        {
            // Lógica para generar un color utilizando redes neuronales
            // Puedes implementar aquí tu algoritmo de generación de colores
            // y devolver el color en un formato adecuado (por ejemplo, como un código hexadecimal).
            return "#FFAABB"; // Ejemplo de un color hexadecimal
        }

    }
}
