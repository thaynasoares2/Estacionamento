 Console.Write("Informe o tamanho do veículo (P/G): ");
        char tamanho = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        Console.Write("Informe o total de minutos estacionado: ");
        int tempoMin = int.Parse(Console.ReadLine());

        Console.Write("Utilizou serviço de valet? (S/N): ");
        char valet = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        Console.Write("Deseja serviço de lavagem? (S/N): ");
        char lavagem = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        // Verificação do tempo máximo permitido (12h = 720 min)
        if (tempoMin > 720)
        {
            Console.WriteLine("\nTempo de permanência inválido! O máximo permitido é de 12 horas (720 minutos).");
            return;
        }

        // Cálculo de horas (como número real)
        double horas = tempoMin / 60.0;

        // Tolerância de 5 minutos
        if (tempoMin <= 65) // 60 min + 5 de tolerância
            horas = 1;

        double valorBase = 0.0;
        string descricao = "";

        // Cálculo do valor base
        if (tamanho == 'G')
        {
            if (horas >= 5)
            {
                valorBase = 80; // diária carro grande
                descricao = "Diária (Carro Grande)";
            }
            else
            {
                int horasAdic = (int)Math.Ceiling(horas - 1);
                if (horasAdic < 0) horasAdic = 0;
                valorBase = 20 + horasAdic * 20;
                descricao = "Hora avulsa (Carro Grande)";
            }
        }
        else if (tamanho == 'P')
        {
            if (horas >= 5)
            {
                valorBase = 50; // diária carro pequeno
                descricao = "Diária (Carro Pequeno)";
            }
            else
            {
                int horasAdic = (int)Math.Ceiling(horas - 1);
                if (horasAdic < 0) horasAdic = 0;
                valorBase = 20 + horasAdic * 10;
                descricao = "Hora avulsa (Carro Pequeno)";
            }
        }
        else
        {
            Console.WriteLine("\nTamanho inválido! Use 'P' para pequeno ou 'G' para grande.");
            return;
        }

        // Serviço de lavagem
        double valorLavagem = 0;
        if (lavagem == 'S')
        {
            valorLavagem = (tamanho == 'G') ? 100 : 50;
        }

        // Valor total antes do valet
        double valorTotal = valorBase + valorLavagem;

        // Aplicação do valet (20%)
        double valorValet = 0;
        if (valet == 'S')
        {
            valorValet = valorTotal * 0.20;
        }

        double valorFinal = valorTotal + valorValet;

        // Saída de resultados
        Console.WriteLine("\n===== RESUMO DO ESTACIONAMENTO =====");
        Console.WriteLine($"Tipo de veículo: {(tamanho == 'G' ? "Grande" : "Pequeno")}");
        Console.WriteLine($"Tempo total: {tempoMin} minutos ({horas:F2} horas)");
        Console.WriteLine($"Tipo de cobrança: {descricao}");
        Console.WriteLine($"Valor base: R$ {valorBase:F2}");
        Console.WriteLine($"Lavagem: R$ {valorLavagem:F2}");
        Console.WriteLine($"Valet (20%): R$ {valorValet:F2}");
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Valor final a pagar: R$ {valorFinal:F2}");
    