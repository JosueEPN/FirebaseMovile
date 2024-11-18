using Firebase.Database;
using Firebase.Database.Query;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Helpers
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebaseClient;

        public FirebaseHelper() 
        {
            firebaseClient = new FirebaseClient("https://moviles2024-a2211-default-rtdb.firebaseio.com/");
        }

        public async Task <List<Medicamento>> GetMedicamentos()
        {
            var medicamento = await firebaseClient
                .Child("Medicamentos")
                .OnceAsync<Medicamento>();
            return medicamento.Select(item => new Medicamento
            {
                Id = item.Key,
                Nombre = item.Object.Nombre,
                Unidades = item.Object.Unidades,
                PrecioUnitario = item.Object.PrecioUnitario,
                Descripcion = item.Object.Descripcion,
                Ubicacion = item.Object.Ubicacion,
                Estado = item.Object.Estado

            }).ToList();
        }

        public async Task AddMedicamento(Medicamento medicamento)
        {
            await firebaseClient
                .Child("Medicamentos")
                .PostAsync(medicamento);
        }
        public async Task UpdateMedicamento (string key, Medicamento medicamento) 
        {
            await firebaseClient
                .Child("Medicamentos")
                .PutAsync(medicamento);
        }

        public async Task DeleteMedicamento(string key) 
        {
            await firebaseClient
                .Child("Medicamentos")
                .Child(key)
                .DeleteAsync();
        }
    }
}
