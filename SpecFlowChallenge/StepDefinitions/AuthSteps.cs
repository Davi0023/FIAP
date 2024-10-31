using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using TechTalk.SpecFlow;

namespace SpecFlowChallenge.StepDefinitions
{
    [Binding]
    public class AuthSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        // Step para definir as credenciais válidas do usuário
        [Given(@"que o usuário tem as credenciais válidas")]
        public void DadoQueOUsuarioTemAsCredenciaisValidas()
        {
            _client = new RestClient("http://localhost:5000");
            _request = new RestRequest("auth/login", Method.Post); // Atualizado para Method.Post
            _request.AddJsonBody(new { username = "user", password = "password" });
        }

        // Step para definir as credenciais inválidas do usuário
        [Given(@"que o usuário tem credenciais inválidas")]
        public void DadoQueOUsuarioTemCredenciaisInvalidas()
        {
            _client = new RestClient("http://localhost:5000");
            _request = new RestRequest("auth/login", Method.Post); // Atualizado para Method.Post
            _request.AddJsonBody(new { username = "user", password = "wrongpassword" });
        }

        // Step para fazer uma requisição de login
        [When(@"o usuário faz uma requisição de login")]
        public async Task QuandoOUsuarioFazUmaRequisicaoDeLogin()
        {
            _response = await _client.ExecuteAsync(_request); // Atualizado para a chamada assíncrona atual
        }

        // Step para validar o status code da resposta
        [Then(@"o sistema responde com status code (.*)")]
        public void EntaoOSistemaRespondeComStatusCode(int statusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        }

        // Step para validar o token de autenticação na resposta de sucesso
        [Then(@"o corpo da resposta contém um token de autenticação válido")]
        public void EntaoOCorpoDaRespostaContemUmTokenDeAutenticacaoValido()
        {
            var responseBody = _response.Content;

            string successSchema = @"
            {
                'type': 'object',
                'properties': {
                    'token': { 'type': 'string' }
                },
                'required': ['token']
            }";

            ValidateJsonSchema(responseBody, successSchema);
        }

        // Step para validar a mensagem de erro na resposta para login inválido
        [Then(@"o corpo da resposta contém uma mensagem de erro")]
        public void EntaoOCorpoDaRespostaContemUmaMensagemDeErro()
        {
            var responseBody = _response.Content;

            string errorSchema = @"
            {
                'type': 'object',
                'properties': {
                    'error': { 'type': 'string' }
                },
                'required': ['error']
            }";

            ValidateJsonSchema(responseBody, errorSchema);
        }

        // Função de validação de contrato JSON usando JSON Schema
        public void ValidateJsonSchema(string jsonResponse, string schema)
        {
            var schemaObject = JSchema.Parse(schema);
            var json = JObject.Parse(jsonResponse);
            bool isValid = json.IsValid(schemaObject, out IList<string> errorMessages);

            isValid.Should().BeTrue("O JSON de resposta não corresponde ao schema esperado. Erros: " + string.Join(", ", errorMessages));
        }
    }
}
