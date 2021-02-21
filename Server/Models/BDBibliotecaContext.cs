﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace appBlazorIntro.Server.Models
{
    public partial class BDBibliotecaContext : DbContext
    {
        public BDBibliotecaContext()
        {
        }

        public BDBibliotecaContext(DbContextOptions<BDBibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Button> Button { get; set; }
        public virtual DbSet<DetalleReserva> DetalleReserva { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<PaginaTipoUsuButton> PaginaTipoUsuButton { get; set; }
        public virtual DbSet<PaginaTipoUsuario> PaginaTipoUsuario { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<ReservaEstado> ReservaEstado { get; set; }
        public virtual DbSet<ReservaHistorial> ReservaHistorial { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<TipoLibro> TipoLibro { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=LAPTOP-74AJBVCC\\SQLEXPRESS;database=BDBiblioteca;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Iidautor)
                    .HasName("PK_Autors");

                entity.Property(e => e.Iidautor).HasColumnName("IIDAUTOR");

                entity.Property(e => e.Apmaterno)
                    .HasColumnName("APMATERNO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Appaterno)
                    .HasColumnName("APPATERNO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Iidpais).HasColumnName("IIDPAIS");

                entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IidpaisNavigation)
                    .WithMany(p => p.Autor)
                    .HasForeignKey(d => d.Iidpais)
                    .HasConstraintName("FK__Autor__IIDPAIS__412EB0B6");

                entity.HasOne(d => d.IidsexoNavigation)
                    .WithMany(p => p.Autor)
                    .HasForeignKey(d => d.Iidsexo)
                    .HasConstraintName("FK__Autor__IIDSEXO__4222D4EF");
            });

            modelBuilder.Entity<Button>(entity =>
            {
                entity.HasKey(e => e.Iidbutton);

                entity.Property(e => e.Iidbutton).HasColumnName("IIDBUTTON");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Nombrebutton)
                    .HasColumnName("NOMBREBUTTON")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleReserva>(entity =>
            {
                entity.HasKey(e => e.Iiddetallereserva);

                entity.Property(e => e.Iiddetallereserva).HasColumnName("IIDDETALLERESERVA");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Iidlibro).HasColumnName("IIDLIBRO");

                entity.Property(e => e.Iidreserva).HasColumnName("IIDRESERVA");

                entity.HasOne(d => d.IidlibroNavigation)
                    .WithMany(p => p.DetalleReserva)
                    .HasForeignKey(d => d.Iidlibro)
                    .HasConstraintName("FK__DetalleRe__IIDLI__4316F928");

                entity.HasOne(d => d.IidreservaNavigation)
                    .WithMany(p => p.DetalleReserva)
                    .HasForeignKey(d => d.Iidreserva)
                    .HasConstraintName("FK__DetalleRe__IIDRE__440B1D61");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Iidlibro)
                    .HasName("PK_Libros");

                entity.Property(e => e.Iidlibro).HasColumnName("IIDLIBRO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Fotocaratula)
                    .HasColumnName("FOTOCARATULA")
                    .IsUnicode(false);

                entity.Property(e => e.Iidautor).HasColumnName("IIDAUTOR");

                entity.Property(e => e.Libropdf)
                    .HasColumnName("LIBROPDF")
                    .IsUnicode(false);

                entity.Property(e => e.Numpaginas).HasColumnName("NUMPAGINAS");

                entity.Property(e => e.Resumen)
                    .HasColumnName("RESUMEN")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Stock).HasColumnName("STOCK");

                entity.Property(e => e.Titulo)
                    .HasColumnName("TITULO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IidautorNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.Iidautor)
                    .HasConstraintName("FK__Libro__IIDAUTOR__44FF419A");
            });

            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.HasKey(e => e.Iidpagina)
                    .HasName("PK_Paginas");

                entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");

                entity.Property(e => e.Accion)
                    .HasColumnName("ACCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Bvisible).HasColumnName("BVISIBLE");

                entity.Property(e => e.Mensaje)
                    .HasColumnName("MENSAJE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaginaTipoUsuButton>(entity =>
            {
                entity.HasKey(e => e.Iidpaginatipousubutton);

                entity.Property(e => e.Iidpaginatipousubutton).HasColumnName("IIDPAGINATIPOUSUBUTTON");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Iidbutton).HasColumnName("IIDBUTTON");

                entity.Property(e => e.Iidpaginatipousuario).HasColumnName("IIDPAGINATIPOUSUARIO");

                entity.HasOne(d => d.IidbuttonNavigation)
                    .WithMany(p => p.PaginaTipoUsuButton)
                    .HasForeignKey(d => d.Iidbutton)
                    .HasConstraintName("FK__PaginaTip__IIDBU__47DBAE45");

                entity.HasOne(d => d.IidpaginatipousuarioNavigation)
                    .WithMany(p => p.PaginaTipoUsuButton)
                    .HasForeignKey(d => d.Iidpaginatipousuario)
                    .HasConstraintName("FK__PaginaTip__IIDPA__48CFD27E");
            });

            modelBuilder.Entity<PaginaTipoUsuario>(entity =>
            {
                entity.HasKey(e => e.Iidpaginatipousuario);

                entity.Property(e => e.Iidpaginatipousuario).HasColumnName("IIDPAGINATIPOUSUARIO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Iidpagina).HasColumnName("IIDPAGINA");

                entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

                entity.HasOne(d => d.IidpaginaNavigation)
                    .WithMany(p => p.PaginaTipoUsuario)
                    .HasForeignKey(d => d.Iidpagina)
                    .HasConstraintName("FK__PaginaTip__IIDPA__45F365D3");

                entity.HasOne(d => d.IidtipousuarioNavigation)
                    .WithMany(p => p.PaginaTipoUsuario)
                    .HasForeignKey(d => d.Iidtipousuario)
                    .HasConstraintName("FK__PaginaTip__IIDTI__46E78A0C");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.Iidpais);

                entity.Property(e => e.Iidpais).HasColumnName("IIDPAIS");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Iidpersona);

                entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");

                entity.Property(e => e.Apmaterno)
                    .HasColumnName("APMATERNO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Appaterno)
                    .HasColumnName("APPATERNO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Btieneusuario).HasColumnName("BTIENEUSUARIO");

                entity.Property(e => e.Correo)
                    .HasColumnName("CORREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("FECHANACIMIENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Iidreserva);

                entity.Property(e => e.Iidreserva).HasColumnName("IIDRESERVA");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Dfechafinreserva)
                    .HasColumnName("DFECHAFINRESERVA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dfechareserva)
                    .HasColumnName("DFECHARESERVA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iidestadoreserva).HasColumnName("IIDESTADORESERVA");

                entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");

                entity.Property(e => e.Numlibros).HasColumnName("NUMLIBROS");

                entity.HasOne(d => d.IidestadoreservaNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Iidestadoreserva)
                    .HasConstraintName("FK__Reserva__IIDESTA__49C3F6B7");
            });

            modelBuilder.Entity<ReservaEstado>(entity =>
            {
                entity.HasKey(e => e.Iidestadoreserva);

                entity.Property(e => e.Iidestadoreserva).HasColumnName("IIDESTADORESERVA");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Vdescripcion)
                    .HasColumnName("VDESCRIPCION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Vnombre)
                    .HasColumnName("VNOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReservaHistorial>(entity =>
            {
                entity.HasKey(e => e.Iidhistorial);

                entity.Property(e => e.Iidhistorial).HasColumnName("IIDHISTORIAL");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Iidestado).HasColumnName("IIDESTADO");

                entity.Property(e => e.Iidreserva).HasColumnName("IIDRESERVA");

                entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");

                entity.Property(e => e.Vobservacion)
                    .HasColumnName("VOBSERVACION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IidestadoNavigation)
                    .WithMany(p => p.ReservaHistorial)
                    .HasForeignKey(d => d.Iidestado)
                    .HasConstraintName("FK__ReservaHi__IIDES__4BAC3F29");

                entity.HasOne(d => d.IidreservaNavigation)
                    .WithMany(p => p.ReservaHistorial)
                    .HasForeignKey(d => d.Iidreserva)
                    .HasConstraintName("FK__ReservaHi__IIDRE__4CA06362");

                entity.HasOne(d => d.IidusuarioNavigation)
                    .WithMany(p => p.ReservaHistorial)
                    .HasForeignKey(d => d.Iidusuario)
                    .HasConstraintName("FK__ReservaHi__IIDUS__4D94879B");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.Iidsexo);

                entity.Property(e => e.Iidsexo).HasColumnName("IIDSEXO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoLibro>(entity =>
            {
                entity.HasKey(e => e.Iidtipolibro);

                entity.Property(e => e.Iidtipolibro).HasColumnName("IIDTIPOLIBRO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Nombretipolibro)
                    .HasColumnName("NOMBRETIPOLIBRO")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.Iidtipousuario);

                entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Iidusuario);

                entity.Property(e => e.Iidusuario).HasColumnName("IIDUSUARIO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");

                entity.Property(e => e.Contra)
                    .HasColumnName("CONTRA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Iidpersona).HasColumnName("IIDPERSONA");

                entity.Property(e => e.Iidtipousuario).HasColumnName("IIDTIPOUSUARIO");

                entity.Property(e => e.Nombreusuario)
                    .HasColumnName("NOMBREUSUARIO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IidpersonaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Iidpersona)
                    .HasConstraintName("FK__Usuario__IIDPERS__4E88ABD4");

                entity.HasOne(d => d.IidtipousuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Iidtipousuario)
                    .HasConstraintName("FK__Usuario__IIDTIPO__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
