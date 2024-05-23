using Microsoft.EntityFrameworkCore;
using MyTe.Models.Entities;

namespace MyTe.Models.Contexts
{
    public class MyTeContext : DbContext
    {
        public MyTeContext(DbContextOptions<MyTeContext> options) : base(options) { }

        public DbSet<WBS> WBSs { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<LancamentoDeHora> Horas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapeamento das entidades para as tabelas
            modelBuilder.Entity<WBS>().ToTable("TB_WBS");
            modelBuilder.Entity<Funcionario>().ToTable("TB_FUNCIONARIOS");
            modelBuilder.Entity<LancamentoDeHora>().ToTable("TB_LANCAMENTO_DE_HORAS");


            //mapeamento das propriedades para as colunas
            //Entidade WBS
            modelBuilder.Entity<WBS>()
                 .Property(p => p.CodigoWBS)
                 .HasColumnName("CODIGO_WBS")
                 .HasMaxLength(10);

            modelBuilder.Entity<WBS>()
                 .Property(p => p.Descricao)
                 .HasColumnName("DESCRICAO")
                 .HasMaxLength(100);

            modelBuilder.Entity<WBS>()
                 .Property(p => p.Tipo)
                 .HasColumnName("TIPO");

            // Entidade Funcionario
            modelBuilder.Entity<Funcionario>()
                 .Property(p => p.Nome)
                 .HasColumnName("NOME")
                 .HasMaxLength(100);

            modelBuilder.Entity<Funcionario>()
                 .Property(p => p.Email)
                 .HasColumnName("EMAIL")
                 .HasMaxLength(100);

            // Entidade Lancamento de hora
            modelBuilder.Entity<LancamentoDeHora>()
                .Property(p => p.FuncionarioId)
                .HasColumnName("ID_FUNCIONARIO");

            modelBuilder.Entity<LancamentoDeHora>()
                .Property(p => p.WBSId)
                .HasColumnName("ID_WBS");

            modelBuilder.Entity<LancamentoDeHora>()
                .Property(p => p.RegistroData)
                .HasColumnName("REGISTRO_DATA");

            modelBuilder.Entity<LancamentoDeHora>()
                .Property(p => p.HorasTrabalhadas)
                .HasColumnName("HORAS_TRABALHADAS");

        }

    }
}
