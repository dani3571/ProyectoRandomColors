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
        public InteractionRequest GetInteractionRequest() 
        {
            InteractionRequest request = new InteractionRequest();
            Message msg = GenerarMessage();
            request.message = msg.message;
            request.messageType = msg.messageType;
            request.contentColor = GenerarColorConRedesNeuronales();
            request.textColor = GenerarColorConRedesNeuronales();
            return request;
        }
        public async Task CreateInteractionAsync(InteractionDTo interactionDTo, string ip)
        {
            try
            {
                string hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var interaction = new Interaction
                {
                    Ip = ip,
                    Hora = ObtenerFechaHoraAleatoria(),
                    Text = interactionDTo.Reaccion,
                    TextColor = interactionDTo.TextColor,
                    ContentColor = interactionDTo.ContentColor,
                    Reaccion = interactionDTo.Reaccion,
                    TipoReaccion = interactionDTo.ReactionType,
                    Imagen = interactionDTo.imagen,
                    Gama = interactionDTo.gama
                };

                await _interactionRepository.CreateAsync(interaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static string ObtenerFechaHoraAleatoria()
        {
            Random random = new Random();

            DateTime fechaInicio = new DateTime(2023, 10, 1);
            DateTime fechaFin = new DateTime(2023, 11, 17);

            int rangoDias = (fechaFin - fechaInicio).Days;
            DateTime fechaAleatoria = fechaInicio.AddDays(random.Next(rangoDias));

            int hora = random.Next(0, 24);
            int minuto = random.Next(0, 60);
            int segundo = random.Next(0, 60);

            string fechaHoraAleatoria = fechaAleatoria.ToString("yyyy-MM-dd") + $" {hora:D2}:{minuto:D2}:{segundo:D2}";

            return fechaHoraAleatoria;
        }
        public async Task<Users> GetUser(string email)
        {
            try
            {
                return await _interactionRepository.GetUserAsync(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserRequest> GetUserReactionAsync(string email)
        {
            try
            {
               return  await _interactionRepository.GetReactionAsync(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task CreateUserAsync(UserDTo user)
        {
            try
            {
                Users newUser = new Users
                {
                    Email = user.Email
                };
                await _interactionRepository.CreateNewUserAsync(newUser);
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
            List<string> colors = new List<string> {
                "#FF0000","#FF5F00", "#FFFF00", "#00FF00", "#0000FF", "#660066", "#FF00FF"
            }; 
            Random rand = new Random();
            return colors[rand.Next(colors.Count)]; 
        }
        private Message GenerarMessage()
        {
            List<Message> messageList = new List<Message> { 
                new Message("¿Cuál es la diferencia entre un niño y una bolsa de basura? La bolsa de basura suele ser más útil.",false),
                new Message("¿Qué tienen en común un niño con cáncer y una piñata? Que a ambos les dan con un palo.",false),
                new Message("¿Por qué los leprosos no pueden jugar a las cartas? Porque tienen las manos trilladas.",false),
                new Message("A mis parientes mayores les gustaba burlarse de mí en las bodas, diciendo: \"¡Tú serás el siguiente!\". Pero dejaron de hacerlo enseguida cuando empecé a hacer lo mismo yo en los funerales.",false),
                new Message("El médico en la consulta. \"Tengo buenas y malas noticias\". \"Deme primero las buenas\", dice el paciente. \"Han llegado los resultados de sus pruebas y solo le quedan dos días de vida\". \"¿Esas son las buenas noticias? ¿Y cuál es la mala?\", dice el paciente. \"Llevo dos días intentando localizarle\".",false),
                new Message("¿Por qué el libro de geografía se despidió del libro de matemáticas? Porque tenía demasiados problemas.",true),
                new Message("¿Qué hace una abeja en el gimnasio? ¡Zum-ba y levanta pesas!",true),
                new Message("¿Qué le dice una iguana a su hermana gemela? Somos iguanitas.",true),
                new Message("¿Por qué los esqueletos no pelean entre sí? Porque no tienen agallas.",true),
                new Message("¿Qué le dice el 1 al 10? Para ser como yo, tienes que ser sincero.",true),
            };
            Random rand = new Random();
            return messageList[rand.Next(messageList.Count)];
        }
    }
}
