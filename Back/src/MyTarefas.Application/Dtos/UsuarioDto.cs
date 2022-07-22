namespace MyTarefas.Application.Dtos
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }  

        public IEnumerable<AcompanhamentoDto> Acompanhamentos { get; set; }    
    }
}