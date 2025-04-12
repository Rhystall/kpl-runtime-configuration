class Program
{
    static void Main(string[] args)
    {
        var config = BankTransferConfig.LoadFromFile("E:\\Data ITTP\\Perkuliahan\\Semester 6\\KPL\\Praktikum\\Praktikum6\\Jurnal\\Modul8_2211104015\\bank_transfer_config.json");

        string lang = config.lang;
        string confirmWord = lang == "en" ? config.confirmation.en : config.confirmation.id;

        Console.WriteLine(lang == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:");
        int amount = int.Parse(Console.ReadLine());

        int fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
        int total = amount + fee;

        Console.WriteLine(lang == "en" ? $"Transfer fee = {fee}" : $"Biaya transfer = {fee}");
        Console.WriteLine(lang == "en" ? $"Total amount = {total}" : $"Total biaya = {total}");

        Console.WriteLine(lang == "en" ? "Select transfer method:" : "Pilih metode transfer:");
        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }
        Console.ReadLine(); // dummy input

        Console.WriteLine(lang == "en" ?
            $"Please type \"{confirmWord}\" to confirm the transaction:" :
            $"Ketik \"{confirmWord}\" untuk mengkonfirmasi transaksi:");
        string confirmInput = Console.ReadLine();

        if (confirmInput.ToLower() == confirmWord.ToLower())
            Console.WriteLine(lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        else
            Console.WriteLine(lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
    }
}
