using Fiap.Web.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Challenge.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        // PROPRIEDADE PARA MANIPULAR AS ENTIDADES
        public virtual DbSet<OrgaoModel> Orgao { get; set; }
        public virtual DbSet<LocalModel> Local { get; set; }
        public virtual DbSet<SensoresModel> Sensores { get; set; }
        public virtual DbSet<OcorrenciaModel> Ocorrencia { get; set; }
        public virtual DbSet<PoluenteModel> Poluente { get; set; }



        // MÉTODO UTILIZADO PARA CRIAÇÃO DOS ELEMENTOS NO BANCO DE DADOS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ENTIDADE ORGAO
            //Crie um script para a entidade OrgaoModel
            modelBuilder.Entity<OrgaoModel>(entity =>
            {
                // Definindo um nome para tabela
                entity.ToTable("Orgao");
                // Definindo chave primária
                entity.HasKey(e => e.id_orgao);
                // Tornando o nome obrigatório
                entity.Property(e => e.nm_orgao).IsRequired();
                // Tornando o telefone obrigatório
                entity.Property(e => e.nr_ddi).IsRequired();
                // Tornando o telefone obrigatório
                entity.Property(e => e.NrDdd).IsRequired();
                // Tornando o telefone obrigatório
                entity.Property(e => e.nr_telefone).IsRequired();
                // Tornando o email obrigatório
                entity.Property(e => e.ds_email).IsRequired();
                // Tornando o endereço obrigatório
                entity.Property(e => e.ds_endereco).IsRequired();
                // Tornando o número obrigatório
                entity.Property(e => e.nr_numero).IsRequired();
                // Tornando o complemento obrigatório
                entity.Property(e => e.ds_complemento).IsRequired();
                // Tornando o bairro obrigatório
                entity.Property(e => e.ds_bairro).IsRequired();
                // Tornando a cidade obrigatória
                entity.Property(e => e.ds_cidade).IsRequired();
                // Tornando o país obrigatório
                entity.Property(e => e.ds_pais).IsRequired();
                // Tornando o CEP obrigatório
                entity.Property(e => e.ds_cep).IsRequired();


            });

            //ENTIDADE LOCAL
            modelBuilder.Entity<LocalModel>(entity =>
            {
                // Definindo um nome para tabela
                entity.ToTable("Local");
                // Definindo chave primária
                entity.HasKey(e => e.id_local);
                // Tornando a coordenada obrigatória
                entity.Property(e => e.ds_coordenadas).IsRequired();
                // Adicionando nome do oceano
                entity.Property(e => e.nm_oceano).IsRequired();
                // Adicionando id do orgão
                entity.HasOne(e => e.Orgao)
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.id_orgao)
                    // Torna a chave estrangeira obrigatória
                    .IsRequired();
            });

            //ENTIDADE SENSORES
            modelBuilder.Entity<SensoresModel>(entity =>
            {
                // Definindo um nome para tabela
                entity.ToTable("Sensores");
                 entity.HasKey(e => e.id_sensor);
                entity.Property(e => e.ds_modelo).IsRequired();
                entity.Property(e => e.ds_fabricante).IsRequired();
                entity.Property(e => e.nm_oceano).IsRequired();
                entity.HasOne(e => e.Local)
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.id_local)
                    // Torna a chave estrangeira obrigatória
                    .IsRequired();
            });

            //ENTIDADE OCORRENCIA
            //Crie um script para a entidade OcorrenciaModel
            modelBuilder.Entity<OcorrenciaModel>(entity =>
            {
                // Definindo um nome para tabela
                entity.ToTable("Ocorrencia");
                // Definindo chave primária
                entity.HasKey(e => e.id_ocorrencia);
                // Tornando a data obrigatória
                entity.Property(e => e.dt_ocorrencia).IsRequired();
                // Adicionando id_sensor
                entity.HasOne(e => e.Sensores)
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.id_sensor)
                    // Torna a chave estrangeira obrigatória
                    .IsRequired();
            });

            //ENTIDADE POLUENTE
            //Crie um script para a entidade PoluenteModel
            modelBuilder.Entity<PoluenteModel>(entity =>
            {
                // Definindo um nome para tabela
                entity.ToTable("Poluente");
                // Definindo chave primária
                entity.HasKey(e => e.id_poluente);
                // Tornando o nome obrigatório
                entity.Property(e => e.nm_poluente).IsRequired();
                // Tornando a descrição obrigatória
                entity.Property(e => e.tp_poluente).IsRequired();
            });




        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
