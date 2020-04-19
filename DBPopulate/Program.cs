using DBPopulate.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate
{
    class Program
    {
        //static PetaPoco.Database geo;
        static PetaPoco.Database kdb;

        // id da Hierarquia dos NUT
        static int hierarquia = 2;

        // id das Divisões Terrioriais correspondentes aos NUT de nível 0, de nível 1, de nivel 2 e de nível 3, respectivamente
        static int divisao0 = 5;
        static int divisao1 = 6;
        static int divisao2 = 7;
        static int divisao3 = 8;

        static string filePath = "C:\\Dissertação\\NUTS_2010.xlsx";

        //id da Hierarquia do território português
        //static int hierarquia = 1;
        //id das Divisões Territoriais correspondentes aos Distritos, Concelhos e Freguesias, respectivamente
        //static int dtDistritos = 9;
        //static int dtConcelhos = 10;
        //static int dtFreguesias = 11;

        static void Main(string[] args)
        {
            Console.WriteLine("Início da importação");
            //geo = new PetaPoco.Database("ctt");
            kdb = new PetaPoco.Database("kdb");

            ExcelPackage source = new ExcelPackage(new FileInfo(filePath));
            ExcelWorksheet ss = source.Workbook.Worksheets.First();
            string codigo;
            int nivel;
            string designacao;
            Unidades_Divisoes nivel0 = new Unidades_Divisoes();
            Unidades_Divisoes nivel1 = new Unidades_Divisoes();
            Unidades_Divisoes nivel2 = new Unidades_Divisoes();

            

            for(int linha = 2; linha < ss.Dimension.End.Row; linha++)
            {
                nivel = int.Parse(ss.Cells[linha, 3].Value.ToString());
                codigo = ss.Cells[linha, 1].Value.ToString();
                designacao = ss.Cells[linha, 2].Value.ToString();
                switch (nivel)
                {
                    case 0: nivel0 = insertNivel(codigo, designacao, divisao0, null); break;
                    case 1: nivel1 = insertNivel(codigo, designacao, divisao1, nivel0); break;
                    case 2: nivel2 = insertNivel(codigo, designacao, divisao2, nivel1); break;
                    case 3: insertNivel(codigo, designacao, divisao3, nivel2); break;
                }
                //switch (nivel)
                //{
                //    case 1: distrito = insertDistrito(codigo, designacao); break;
                //    case 2: concelho = insertConcelho(distrito, codigo, designacao); break;
                //    case 3: insertFreguesia(concelho, codigo, designacao); break;
                //}

            }



            Console.ReadLine();
        }

        private static Unidades_Divisoes insertNivel(string codigo, string designacao, int divisao, Unidades_Divisoes parent)
        {
            Console.WriteLine("A inserir nivel " + codigo);
            Nomes nome = insertNome(designacao);
            Nomes alternativo = insertNome(codigo);
            UnidadesTerritoriais ut = new UnidadesTerritoriais { NomesId = nome.NomesId };
            kdb.Insert(ut);
            UT_NomesAlternativos utAlt = new UT_NomesAlternativos { NomesId = alternativo.NomesId, UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId };
            kdb.Insert(utAlt);

            Unidades_Divisoes ud = new Unidades_Divisoes { UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId, DivisoesTerritoriaisId = divisao };
            kdb.Insert(ud);

            Unidades_Divisoes_Hierarquias udh = new Unidades_Divisoes_Hierarquias
            {
                HierarquiasTerritoriaisId = hierarquia,
                UnidadesDivisoesId = ud.UnidadesDivisoesId
            };
            if (parent != null)
                udh.ParentId = parent.UnidadesDivisoesId;

            kdb.Insert(udh);

            return ud;
        }

        //private static void insertFreguesia(Unidades_Divisoes concelho, string codigo, string designacao)
        //{
        //    Console.WriteLine("      UD concelho: " + concelho.UnidadesDivisoesId + " - A inserir freguesia de " + designacao);
        //    Nomes nome = insertNome(designacao);
        //    Nomes alternativo = insertNome(codigo);
        //    UnidadesTerritoriais ut = new UnidadesTerritoriais { NomesId = nome.NomesId };
        //    kdb.Insert(ut);
        //    UT_NomesAlternativos utAlt = new UT_NomesAlternativos { NomesId = alternativo.NomesId, UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId };
        //    kdb.Insert(utAlt);

        //    Unidades_Divisoes ud = new Unidades_Divisoes { UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId, DivisoesTerritoriaisId = dtFreguesias };
        //    kdb.Insert(ud);
        //    Unidades_Divisoes_Hierarquias udh = new Unidades_Divisoes_Hierarquias
        //    {
        //        HierarquiasTerritoriaisId = hierarquia,
        //        UnidadesDivisoesId = ud.UnidadesDivisoesId,
        //        ParentId = concelho.UnidadesDivisoesId
        //    };

        //    kdb.Insert(udh);
        //}

        //private static Unidades_Divisoes insertConcelho(Unidades_Divisoes distrito, string codigo, string designacao)
        //{
        //    Console.WriteLine("   UD Distrito: " + distrito.UnidadesDivisoesId + " - A inserir concelho de " + designacao);
        //    Nomes nome = insertNome(designacao);
        //    Nomes alternativo = insertNome(codigo);
        //    UnidadesTerritoriais ut = new UnidadesTerritoriais { NomesId = nome.NomesId };
        //    kdb.Insert(ut);
        //    UT_NomesAlternativos utAlt = new UT_NomesAlternativos { NomesId = alternativo.NomesId, UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId };
        //    kdb.Insert(utAlt);

        //    Unidades_Divisoes ud = new Unidades_Divisoes { UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId, DivisoesTerritoriaisId = dtConcelhos };
        //    kdb.Insert(ud);
        //    Unidades_Divisoes_Hierarquias udh = new Unidades_Divisoes_Hierarquias
        //    {
        //        HierarquiasTerritoriaisId = hierarquia,
        //        UnidadesDivisoesId = ud.UnidadesDivisoesId,
        //        ParentId = distrito.UnidadesDivisoesId
        //    };

        //    kdb.Insert(udh);

        //    return ud;

        //}

        //private static Unidades_Divisoes insertDistrito(string codigo, string designacao)
        //{
        //    Console.WriteLine("A inserir distrito de " + designacao);
        //    Nomes nome = insertNome(designacao);
        //    Nomes alternativo = insertNome(codigo);
        //    UnidadesTerritoriais ut = new UnidadesTerritoriais { NomesId = nome.NomesId };
        //    kdb.Insert(ut);
        //    UT_NomesAlternativos utAlt = new UT_NomesAlternativos { NomesId = alternativo.NomesId, UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId };
        //    kdb.Insert(utAlt);

        //    Unidades_Divisoes ud = new Unidades_Divisoes { UnidadesTerritoriaisId = ut.UnidadesTerritoriaisId, DivisoesTerritoriaisId = dtDistritos };
        //    kdb.Insert(ud);

        //    Unidades_Divisoes_Hierarquias udh = new Unidades_Divisoes_Hierarquias { HierarquiasTerritoriaisId = hierarquia, UnidadesDivisoesId = ud.UnidadesDivisoesId };
        //    switch(codigo[0])
        //    {
        //        case '3': udh.ParentId = 2; break;
        //        case '4': udh.ParentId = 3; break;
        //        default: udh.ParentId = 1; break;
        //    }
        //    kdb.Insert(udh);

        //    return ud;
        //}

        private static Nomes insertNome(string designacao)
        {
            if(designacao.IndexOf("(") > -1)
            {
                int start = designacao.IndexOf("(") + 1;
                int end = designacao.IndexOf(")");

                designacao = designacao.Substring(start, end - start);
            }
            PetaPoco.Sql query = PetaPoco.Sql.Builder;
            query.Append("select * from Nomes where Nome = @0", designacao);
            Nomes nome = kdb.SingleOrDefault<Nomes>(query);
            if (nome != null)
                return nome;

            nome = new Nomes { Idioma = "en", Nome = designacao };

            kdb.Insert(nome);
            return nome;
        }

        private static void SystemExit()
        {
            Console.Clear();
            Console.WriteLine("Programa terminado");
            Console.ReadLine();
            System.Environment.Exit(0);
        }
    }
}
