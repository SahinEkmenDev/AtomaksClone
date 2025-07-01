using AtomaksClone.Data;
using AtomaksClone.Models;

namespace AtomaksClone.Services
{
    public class SeedService
    {
        private readonly ApplicationDbContext _context;

        public SeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            if (_context.Questions.Any()) return;

            // Ürünler
            var products = new List<Product>
{
    new Product
    {
        Title = "DİZEL",
        Desc = "Güçlü ve uzun süreli enerji için.",
        Color = "#FF7F2A",
        Detail = "Dizel, seni yavaşça ama istikrarlı şekilde ileri taşır. Zamanla artan etkisiyle uzun günlere eşlik eder.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751202799/atomaks-products/mblidw5c10i7hykcsngn.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "BENZİN",
        Desc = "Kısa sürede yüksek performans.",
        Color = "#FF4B5C",
        Detail = "Benzin, hızlı bir enerji patlaması sunar. Dakikalar içinde yenilen, durma, devam et!",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751202881/atomaks-products/sfwov4b3kanobwwy518n.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "BOMBA",
        Desc = "Derinlerde saklı, sürprizlerle dolu.",
        Color = "#FFD600",
        Detail = "Bomba, ilk yudumda seni şaşırtır. Katman katman açılan enerjisiyle sıradanlığa meydan okur.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751202946/atomaks-products/dprxe4to9pv5bdshwvdv.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "ROKET",
        Desc = "Yüksekten uçmak isteyenlere.",
        Color = "#1DE9B6",
        Detail = "Roket, hız ve ferahlığın birleşimi. Gününü yukarı taşıyan bir lezzet patlaması seni bekliyor.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751203025/atomaks-products/irvbmqpqg57mqgbp6cdk.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "OREO ATOM",
        Desc = "Tatlı bir kaçışın enerjik hali.",
        Color = "#8b5cf6",
        Detail = "Oreo atom, çocukluğun tatlı anılarına enerjiyle dokunur. Yumuşak, yoğun ve mutlu edici.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751203128/atomaks-products/hcjuzmf46trnhk7o1iqm.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "COFFE ATOM",
        Desc = "Yoğunluk ve enerji tek bedende.",
        Color = "#885434",
        Detail = "Coffee atom, tatlılıkla sertliğin dengesi. Uyanmak, toparlanmak ya da yola devam etmek isteyenlere.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751203218/atomaks-products/hctydwrpgl5qhfdz6gxc.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "BAZUKA",
        Desc = "Sınır tanımayanlara özel bir deneyim.",
        Color = "#FF9100",
        Detail = "Bazuka, enerjisini saklamaz. Ne aradığını biliyorsan tam üstüne gelir. Cesur ol, tadını çıkar!",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751203353/atomaks-products/nctrvy8maztbyg9dk2x3.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "TURBO",
        Desc = "Yeni nesil bir enerji formu.",
        Color = "#4ade80",
        Detail = "Turbo, klasik sınırları aşıp farklı dünyaları bir araya getirir. Her şeyin en iyisi tek bardağa sığdı.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751203469/atomaks-products/pa6w9tejlvu3xjvzklpi.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    },
    new Product
    {
        Title = "ATOM",
        Desc = "Klasiklerin ötesinde, her zaman hazır.",
        Color = "#ef4444",
        Detail = "Atom, tanıdık bir dost gibi. Dengeli, enerjik ve her daim güvenilir. Hızlı bir başlangıç için birebir.",
        ImageUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751203505/atomaks-products/h1jq3rm25jch6ewsluml.png",
        CreatedAt = DateTime.UtcNow,
        IsActive = true
    }
};

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();

            // Sorular
            var questions = new List<Question>
            {
                new Question { Text = "Tatlı tercihin nedir? ", CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281814/cupcake_tcbwyw.png" },
                new Question { Text = "En sevdiğin meyve? ", CreatedAt = DateTime.UtcNow, IsActive = true ,IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281813/fruit_1_fdn7lq.png" },
                new Question { Text = "Ağzına kıtır kıtır gelen bir şey olsa? ", CreatedAt = DateTime.UtcNow, IsActive = true ,IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281813/crumbs_uyaq7z.png" },
                new Question { Text = "Sabah seni hangisi uyandırır? ", CreatedAt = DateTime.UtcNow, IsActive = true,IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281812/sun_kxc64c.png" },
                new Question { Text = "Bir içecek seni nasıl hissettirmeli? ", CreatedAt = DateTime.UtcNow, IsActive = true ,IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281811/dial_gqmjvv.png"},
                new Question { Text = "Bir içecek hayal et - rengine göre seçsen? ", CreatedAt = DateTime.UtcNow, IsActive = true ,IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281811/drink_g1sway.png"},
                new Question { Text = "Sihirli bir malzeme ekleyecek olsan? ", CreatedAt = DateTime.UtcNow, IsActive = true ,IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281812/potion_klmyjh.png"}
            };

            _context.Questions.AddRange(questions);
            await _context.SaveChangesAsync();

            // Cevaplar
            var answers = new List<Answer>();
            var answerImpacts = new List<AnswerImpact>();

            // Ürünleri değişkenlere ata
            var dizel = products[0];
            var benzin = products[1];
            var bomba = products[2];
            var roket = products[3];
            var oreoAtom = products[4];
            var coffeAtom = products[5];
            var bazuka = products[6];
            var turbo = products[7];
            var atom = products[8];

            // Soru 1: Tatlı tercihin nedir? 🍫
            var a1_1 = new Answer { Text = "Çikolata", QuestionId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277367/chocolate-bar_zwepzv.png" };
            var a1_2 = new Answer { Text = "Bal", QuestionId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277367/honey_ntqkng.png" };
            var a1_3 = new Answer { Text = "Pekmez", QuestionId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277367/molasses_puk4aw.png" };
            var a1_4 = new Answer { Text = "Oreo", QuestionId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277367/candy_ubzhcm.png" };
            var a1_5 = new Answer { Text = "Hiçbiri", QuestionId = 1, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277362/no-entry_ceepdp.png" };
            answers.AddRange(new[] { a1_1, a1_2, a1_3, a1_4, a1_5 });

            // Soru 2: En sevdiğin meyve? 🍌
            var a2_1 = new Answer { Text = "Muz", QuestionId = 2, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277362/bananas_hh7wbx.png" };
            var a2_2 = new Answer { Text = "Çilek", QuestionId = 2, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277362/strawberry_ybooqn.png" };
            var a2_3 = new Answer { Text = "Kavun", QuestionId = 2, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277361/melon_agbxui.png" };
            var a2_4 = new Answer { Text = "Ananas", QuestionId = 2, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277361/pineapple_ebeizs.png" };
            var a2_5 = new Answer { Text = "Ejder meyvesi", QuestionId = 2, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277349/dragon-fruit_zvdgiz.png" };
            answers.AddRange(new[] { a2_1, a2_2, a2_3, a2_4, a2_5 });

            // Soru 3: Ağzına kıtır kıtır gelen bir şey olsa? 🌰
            var a3_1 = new Answer { Text = "Kuruyemiş", QuestionId = 3, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277348/nuts_l2uknq.png" };
            var a3_2 = new Answer { Text = "Oreo parçaları", QuestionId = 3, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751281813/crumbs_uyaq7z.png" };
            var a3_3 = new Answer { Text = "Hiçbiri", QuestionId = 3, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277362/no-entry_ceepdp.png" };
            var a3_4 = new Answer { Text = "Biraz kahve sosu", QuestionId = 3, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277347/bag_yqwntk.png" };
            var a3_5 = new Answer { Text = "Tahin", QuestionId = 3, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277347/tahini_jovnei.png" };
            answers.AddRange(new[] { a3_1, a3_2, a3_3, a3_4, a3_5 });

            // Soru 4: Sabah seni hangisi uyandırır? ☀
            var a4_1 = new Answer { Text = "Süt & Muz", QuestionId = 4, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277348/banana-milk_cfaj1o.png" };
            var a4_2 = new Answer { Text = "Reçel & Tahin & Pekmez", QuestionId = 4, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277347/mixing_reu6na.png" };
            var a4_3 = new Answer { Text = "Kahve", QuestionId = 4, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277349/coffee-cup_kf8nrf.png" };
            var a4_4 = new Answer { Text = "Portakal ve ejder meyvesi", QuestionId = 4, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277348/fruit_bmhrau.png" };
            var a4_5 = new Answer { Text = "Yoğun çikolata", QuestionId = 4, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277348/chocolate_uo4qta.png" };
            answers.AddRange(new[] { a4_1, a4_2, a4_3, a4_4, a4_5 });

            // Soru 5: Bir içecek seni nasıl hissettirmeli? 🚗
            var a5_1 = new Answer { Text = "Hafif ama enerji veren", QuestionId = 5, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277348/wireless_o5yuhg.png" };
            var a5_2 = new Answer { Text = "Kıvamlı, tok tutan", QuestionId = 5, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277347/jam_ajh53t.png" };
            var a5_3 = new Answer { Text = "Tatlı ama güçlü", QuestionId = 5, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751291676/arm-muscle_xbf9fb.png" };
            var a5_4 = new Answer { Text = "Egzotik ve serin", QuestionId = 5, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751291751/pina-colada_lhul2h.png" };
            var a5_5 = new Answer { Text = "Güçlü, karışık, tam turbo", QuestionId = 5, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277347/mixing_reu6na.png" };
            answers.AddRange(new[] { a5_1, a5_2, a5_3, a5_4, a5_5 });

            // Soru 6: Bir içecek hayal et - rengine göre seçsen? 🥤
            var a6_1 = new Answer { Text = "Açık bej ", QuestionId = 6, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751292228/soft-drink_hnpueg.png" };
            var a6_2 = new Answer { Text = "Kahverengi ", QuestionId = 6, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751292229/drink_1_skgczc.png" };
            var a6_3 = new Answer { Text = "Koyu kahve ", QuestionId = 6, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751292228/pint_bzdgcx.png" };
            var a6_4 = new Answer { Text = "Pembe ", QuestionId = 6, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751292228/milkshake_ihbsi7.png" };
            var a6_5 = new Answer { Text = "Turuncu / sarı / mor tonlu ", QuestionId = 6, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751292228/drink_2_h5xs1y.png" };
            answers.AddRange(new[] { a6_1, a6_2, a6_3, a6_4, a6_5 });

            // Soru 7: Sihirli bir malzeme ekleyecek olsan? 🌟
            var a7_1 = new Answer { Text = "Keçiboynuzu özü", QuestionId = 7, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277367/molasses_puk4aw.png" };
            var a7_2 = new Answer { Text = "Oreo", QuestionId = 7, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277367/candy_ubzhcm.png" };
            var a7_3 = new Answer { Text = "Kahve aroması", QuestionId = 7, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277347/coffee_sainme.png" };
            var a7_4 = new Answer { Text = "Ejder meyvesi", QuestionId = 7, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277349/dragon-fruit_zvdgiz.png" };
            var a7_5 = new Answer { Text = "Çilek", QuestionId = 7, CreatedAt = DateTime.UtcNow, IsActive = true, IconUrl = "https://res.cloudinary.com/dnflicowh/image/upload/v1751277362/strawberry_ybooqn.png" };
            answers.AddRange(new[] { a7_1, a7_2, a7_3, a7_4, a7_5 });

            _context.Answers.AddRange(answers);
            await _context.SaveChangesAsync();

            // Answer Impacts - Her cevabın ürünlere verdiği puanlar

            // Soru 1: Tatlı tercihin nedir? 🍫
            // Çikolata -> ATOM: +2, BOMBA: +2, OREO ATOM: +3
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_1.Id, ProductId = 9, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_1.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_1.Id, ProductId = 5, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Bal -> ATOM: +3, BOMBA: +2, BAZUKA: +1, ROKET: +1
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_2.Id, ProductId = 9, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_2.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_2.Id, ProductId = 7, Point = 1, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_2.Id, ProductId = 4, Point = 1, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Pekmez -> BAZUKA: +3, ROKET: +3
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_3.Id, ProductId = 7, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_3.Id, ProductId = 4, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Oreo -> OREO ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_4.Id, ProductId = 5, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Hiçbiri -> DİZEL: +2, BENZİN: +2, TURBO: +1
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_5.Id, ProductId = 1, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_5.Id, ProductId = 2, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a1_5.Id, ProductId = 8, Point = 1, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Soru 2: En sevdiğin meyve? 🍌
            // Muz -> ATOM: +3, BOMBA: +2, OREO ATOM: +1
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_1.Id, ProductId = 9, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_1.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_1.Id, ProductId = 5, Point = 1, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Çilek -> ATOM: +2, BOMBA: +2, DİZEL: +1
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_2.Id, ProductId = 9, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_2.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_2.Id, ProductId = 1, Point = 1, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Kavun -> DİZEL: +3, BENZİN: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_3.Id, ProductId = 1, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_3.Id, ProductId = 2, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Ananas -> BENZİN: +3, TURBO: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_4.Id, ProductId = 2, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_4.Id, ProductId = 8, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Ejder meyvesi -> TURBO: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_5.Id, ProductId = 8, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a2_5.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Soru 3: Ağzına kıtır kıtır gelen bir şey olsa? 🌰
            // Kuruyemiş -> DİZEL: +2, BENZİN: +2, TURBO: +1
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_1.Id, ProductId = 1, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_1.Id, ProductId = 2, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_1.Id, ProductId = 8, Point = 1, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Oreo parçaları -> OREO ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_2.Id, ProductId = 5, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Hiçbiri -> ATOM: +2, BOMBA: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_3.Id, ProductId = 9, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_3.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Biraz kahve sosu -> COFFE ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_4.Id, ProductId = 6, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Tahin -> BAZUKA: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_5.Id, ProductId = 7, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a3_5.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Soru 4: Sabah seni hangisi uyandırır? ☀
            // Süt & Muz -> ATOM: +3, BOMBA: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_1.Id, ProductId = 9, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_1.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Reçel & Tahin & Pekmez -> BAZUKA: +3, ROKET: +3
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_2.Id, ProductId = 7, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_2.Id, ProductId = 4, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Kahve -> COFFE ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_3.Id, ProductId = 6, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Portakal ve ejder meyvesi -> TURBO: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_4.Id, ProductId = 8, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_4.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Yoğun çikolata -> ATOM: +3, BOMBA: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_5.Id, ProductId = 9, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a4_5.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Soru 5: Bir içecek seni nasıl hissettirmeli? 🚗
            // Hafif ama enerji veren -> DİZEL: +3, BENZİN: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_1.Id, ProductId = 1, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_1.Id, ProductId = 2, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Kıvamlı, tok tutan -> BAZUKA: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_2.Id, ProductId = 7, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_2.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Tatlı ama güçlü -> ATOM: +3, BOMBA: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_3.Id, ProductId = 9, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_3.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Egzotik ve serin -> TURBO: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_4.Id, ProductId = 8, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_4.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Güçlü, karışık, tam turbo -> TURBO: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a5_5.Id, ProductId = 8, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Soru 6: Bir içecek hayal et - rengine göre seçsen? 🥤
            // Açık bej (muzlu süt gibi) -> ATOM: +3, BOMBA: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_1.Id, ProductId = 9, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_1.Id, ProductId = 3, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Kahverengi (çikolatalı-bombamsı) -> BOMBA: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_2.Id, ProductId = 3, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Koyu kahve (kahveli bazukamsı) -> COFFE ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_3.Id, ProductId = 6, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Pembe (çilekli) -> ATOM: +2, DİZEL: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_4.Id, ProductId = 9, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_4.Id, ProductId = 1, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Turuncu / sarı / mor tonlu (meyve karışımı) -> BENZİN: +3, TURBO: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_5.Id, ProductId = 2, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a6_5.Id, ProductId = 8, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Soru 7: Sihirli bir malzeme ekleyecek olsan? 🌟
            // Keçiboynuzu özü -> BAZUKA: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_1.Id, ProductId = 7, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_1.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Oreo -> OREO ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_2.Id, ProductId = 5, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Kahve aroması -> COFFE ATOM: +4
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_3.Id, ProductId = 6, Point = 4, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Ejder meyvesi -> TURBO: +3, ROKET: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_4.Id, ProductId = 8, Point = 3, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_4.Id, ProductId = 4, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            // Çilek -> ATOM: +2, DİZEL: +2
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_5.Id, ProductId = 9, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });
            answerImpacts.Add(new AnswerImpact { AnswerId = a7_5.Id, ProductId = 1, Point = 2, CreatedAt = DateTime.UtcNow, IsActive = true });

            _context.AnswerImpacts.AddRange(answerImpacts);
            await _context.SaveChangesAsync();
        }
    }
}
