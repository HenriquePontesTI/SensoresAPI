using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Bson;
using Sensores_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensores_API.Services
{
    public class SensorServices
    {
        private readonly IMongoCollection<Sensor> _SensorsItens;

        public SensorServices(ISensoresDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _SensorsItens = database.GetCollection<Sensor>(settings.SensorCollectionName);
        }

        public List<Sensor> Get() =>
    _SensorsItens.Find(Sensor => true).ToList();

        public Sensor Get(ObjectId id) =>
            _SensorsItens.Find<Sensor>(Sensor => Sensor.id == id).FirstOrDefault();

        public Sensor Create(Sensor Sensor)
        {
            Sensor.id = ObjectId.GenerateNewId();
            Sensor.timestamp = (DateTime.UtcNow.Subtract(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))).TotalSeconds.ToString();

            _SensorsItens.InsertOne(Sensor);
            return Sensor;
        }

        public void Update(ObjectId id, Sensor SensorIn) =>
            _SensorsItens.ReplaceOne(Sensor => Sensor.id == id, SensorIn);

        public void Remove(Sensor SensorIn) =>
            _SensorsItens.DeleteOne(Sensor => Sensor.id == SensorIn.id);

        public void Remove(ObjectId id) =>
            _SensorsItens.DeleteOne(Sensor => Sensor.id == id);
    }
}