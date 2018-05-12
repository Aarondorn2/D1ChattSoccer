using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace D1SoccerService {
    public static class JsonApi {
        public static Response Response(dynamic model) {
            return Response(new[] { model });
        }
        public static Response Response(dynamic[] models) {
            return new TextResponse(JsonConvert.SerializeObject(new JsonApiResponseModel(models)), "application/json", Encoding.UTF8);
        }
    }

    public class JsonApiResponseModel {
        public JsonApiResponseModel(dynamic[] models) {
            var data = new List<JsonApiData>();
            foreach (var model in models) {
                data.Add(new JsonApiData(model));
            }

            Data = data.ToArray();
        }

        [JsonProperty("data")]
        public JsonApiData[] Data { get; set; }
    }

    public class JsonApiData {
        public JsonApiData(dynamic model) {
            Type = ((System.Type)model.GetType()).Name;
            Id = model.Id;
            Attributes = model;
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public dynamic Attributes { get; set; }
    }
}
