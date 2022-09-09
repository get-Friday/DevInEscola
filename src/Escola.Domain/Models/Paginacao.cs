namespace Escola.Domain.Models
{
    public class Paginacao
    {
        // Tranca a classe para paginar apenas de 5 em 5
        public int Take = 5;
        public int Skip = 5;
        public Paginacao(int pagina)
        {
            Take *= pagina;
            Skip *= --pagina;
        }
    }
}
