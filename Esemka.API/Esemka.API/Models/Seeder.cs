namespace Esemka.Models
{
    public static class Seeder
    {
        public static void Seed(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<EsemkaContext>();

            if(db == null)
            {
                return;
            }

            List<User> userList = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Username = "mahdi",
                    Password = "1234",
                    Fullname = "Mahdi Jokar",
                    PhoneNumber = "081234567890"
                },
                new User
                {
                    Id = 2,
                    Username = "gav",
                    Password = "1234",
                    Fullname = "Gavriel Satrio WIdjaya",
                    PhoneNumber = "081234567890"
                },
                new User
                {
                    Id = 3,
                    Username = "argi",
                    Password = "1234",
                    Fullname = "Argi Purwanto",
                    PhoneNumber = "081234567890"
                },
                new User
                {
                    Id = 4,
                    Username = "steve",
                    Password = "1234",
                    Fullname = "Steven Taniardi",
                    PhoneNumber = "081234567890"
                },
                new User
                {
                    Id = 5,
                    Username = "jsmith87",
                    Password = "p@ssw0rd",
                    Fullname = "John Smith",
                    PhoneNumber = "123-456-7890"
                },
                new User
                {
                    Id = 6,
                    Username = "janedoe123",
                    Password = "d0e!Pass",
                    Fullname = "Jane Doe",
                    PhoneNumber = "987-654-3210"
                },
                new User
                {
                    Id = 7,
                    Username = "rjohnson22",
                    Password = "r0b3rtP@ss",
                    Fullname = "Robert Johnson",
                    PhoneNumber = "555-555-5555"
                },
                new User
                {
                    Id = 8,
                    Username = "emily_white",
                    Password = "3milyP@ss",
                    Fullname = "Emily White",
                    PhoneNumber = "111-222-3333"
                },
                new User
                {
                    Id = 9,
                    Username = "michaelb",
                    Password = "M!ch@el12",
                    Fullname = "Michael Brown",
                    PhoneNumber = "444-444-4444"
                },
                new User
                {
                    Id = 10,
                    Username = "jenndavis",
                    Password = "Jenn!Pass",
                    Fullname = "Jennifer Davis",
                    PhoneNumber = "777-777-7777"
                },
                new User
                {
                    Id = 11,
                    Username = "davId_lee",
                    Password = "D@vIdL33",
                    Fullname = "DavId Lee",
                    PhoneNumber = "888-888-8888"
                },
                new User
                {
                    Id = 12,
                    Username = "sarahw",
                    Password = "S@rah#2023",
                    Fullname = "Sarah Wilson",
                    PhoneNumber = "999-999-9999"
                },
                new User
                {
                    Id = 13,
                    Username = "kevin_a",
                    Password = "K3vinRulz!",
                    Fullname = "Kevin Anderson",
                    PhoneNumber = "666-666-6666"
                },
                new User
                {
                    Id = 14,
                    Username = "lisamartin",
                    Password = "L1s@M@rtin",
                    Fullname = "Lisa Martin",
                    PhoneNumber = "333-333-3333"
                },
                new User
                {
                    Id = 15,
                    Username = "will_taylor",
                    Password = "WillP@ss",
                    Fullname = "William Taylor",
                    PhoneNumber = "222-222-2222"
                },
                new User
                {
                    Id = 16,
                    Username = "jesshall",
                    Password = "J3ss1c@H",
                    Fullname = "Jessica Hall",
                    PhoneNumber = "555-123-4567"
                },
                new User
                {
                    Id = 17,
                    Username = "andrewc",
                    Password = "4ndr3wC!",
                    Fullname = "Andrew Clark",
                    PhoneNumber = "789-789-7890"
                },
                new User
                {
                    Id = 18,
                    Username = "michyoun",
                    Password = "M!ch#2023",
                    Fullname = "Michelle Young",
                    PhoneNumber = "456-789-0123"
                },
                new User
                {
                    Id = 19,
                    Username = "daniel_turn",
                    Password = "D@n!3L",
                    Fullname = "Daniel Turner",
                    PhoneNumber = "123-987-6543"
                },
                new User
                {
                    Id = 20,
                    Username = "amanda_l",
                    Password = "4m@nd@L",
                    Fullname = "Amanda Lewis",
                    PhoneNumber = "987-123-4567"
                },
                new User
                {
                    Id = 21,
                    Username = "rich_p",
                    Password = "R!ch@rd99",
                    Fullname = "Richard Parker",
                    PhoneNumber = "222-333-4444"
                },
                new User
                {
                    Id = 22,
                    Username = "laura_h",
                    Password = "Laur@H",
                    Fullname = "Laura Harris",
                    PhoneNumber = "111-999-8888"
                },
                new User
                {
                    Id = 23,
                    Username = "thomas_m",
                    Password = "T0mM00re",
                    Fullname = "Thomas Moore",
                    PhoneNumber = "777-555-3333"
                },
                new User
                {
                    Id = 24,
                    Username = "eliz_k",
                    Password = "3l!z@b3th",
                    Fullname = "Elizabeth King",
                    PhoneNumber = "444-777-1111"
                },
                new User { Id = 25, Username = "mary_j", Password = "M@ryP@ss", Fullname = "Mary Johnson", PhoneNumber = "555-123-4567" },
                new User { Id = 26, Username = "johndoe123", Password = "D0e#P@ss", Fullname = "John Doe", PhoneNumber = "987-654-3210" },
                new User { Id = 27, Username = "rsmith", Password = "R0bertS!", Fullname = "Robert Smith", PhoneNumber = "111-222-3333" },
                new User { Id = 28, Username = "emily_jones", Password = "3m1lyJ@nes", Fullname = "Emily Jones", PhoneNumber = "555-555-5555" },
                new User { Id = 29, Username = "michaela", Password = "M!chael@2023", Fullname = "Michaela Adams", PhoneNumber = "444-444-4444" },
                new User { Id = 30, Username = "jenn_miller", Password = "JennM1ll3r", Fullname = "Jennifer Miller", PhoneNumber = "777-777-7777" },
                new User { Id = 31, Username = "david_hall", Password = "Dav1dH@ll", Fullname = "David Hall", PhoneNumber = "888-888-8888" },
                new User { Id = 32, Username = "sarah_g", Password = "S@r@hG0", Fullname = "Sarah Green", PhoneNumber = "999-999-9999" },
                new User { Id = 33, Username = "chris_w", Password = "Chri$W", Fullname = "Chris Wilson", PhoneNumber = "666-666-6666" },
                new User { Id = 34, Username = "alex_smith", Password = "Al3xSm!th", Fullname = "Alex Smith", PhoneNumber = "333-333-3333" },
                new User { Id = 35, Username = "katetaylor", Password = "K@t3Tayl0r", Fullname = "Kate Taylor", PhoneNumber = "222-222-2222" },
                new User { Id = 36, Username = "james_m", Password = "Jam3sM!", Fullname = "James Mitchell", PhoneNumber = "555-123-4567" },
                new User { Id = 37, Username = "andrewp", Password = "4ndr3wP@ss", Fullname = "Andrew Peterson", PhoneNumber = "789-789-7890" },
                new User { Id = 38, Username = "michellec", Password = "M1ch3ll3C", Fullname = "Michelle Clark", PhoneNumber = "456-789-0123" },
                new User { Id = 39, Username = "danielle_t", Password = "D@ni3lleT", Fullname = "Danielle Thompson", PhoneNumber = "123-987-6543" },
                new User { Id = 40, Username = "sam_l", Password = "SamL@123", Fullname = "Samuel Lewis", PhoneNumber = "987-123-4567" },
                new User { Id = 41, Username = "robert_p", Password = "R0b3rtP#", Fullname = "Robert Patterson", PhoneNumber = "222-333-4444" },
                new User { Id = 42, Username = "laura_m", Password = "Laur@M", Fullname = "Laura Martinez", PhoneNumber = "111-999-8888" },
                new User { Id = 43, Username = "thomas_k", Password = "Th0m@sk!ng", Fullname = "Thomas King", PhoneNumber = "777-555-3333" },
                new User { Id = 44, Username = "eliza_b", Password = "3lizaB@nks", Fullname = "Eliza Banks", PhoneNumber = "444-777-1111" },
                new User { Id = 45, Username = "peter_g", Password = "P3t3rG!", Fullname = "Peter Graham", PhoneNumber = "555-555-5555" },
                new User { Id = 46, Username = "grace_w", Password = "Gr@ceW", Fullname = "Grace White", PhoneNumber = "111-222-3333" },
                new User { Id = 47, Username = "matt_j", Password = "M@tt123", Fullname = "Matt Johnson", PhoneNumber = "555-123-4567" },
                new User { Id = 48, Username = "susan_d", Password = "Sus@nD", Fullname = "Susan Davis", PhoneNumber = "987-654-3210" },
                new User { Id = 49, Username = "jack_r", Password = "J@ckRul3s", Fullname = "Jack Robinson", PhoneNumber = "555-555-5555" },
                new User { Id = 50, Username = "olivia_m", Password = "Ol!v!@M", Fullname = "Olivia Moore", PhoneNumber = "444-444-4444" },
                new User { Id = 51, Username = "daniel_w", Password = "D@n!3LW", Fullname = "Daniel Williams", PhoneNumber = "777-777-7777" },
                new User { Id = 52, Username = "linda_c", Password = "L!ndaC", Fullname = "Linda Carter", PhoneNumber = "888-888-8888" },
                new User { Id = 53, Username = "william_j", Password = "W1ll!@mJ", Fullname = "William Jenkins", PhoneNumber = "999-999-9999" }
            };


            List<Ekskul> ekskulList = new List<Ekskul>
            {
                new Ekskul
                {
                    Id = 1,
                    Name = "Sepak Bola",
                    Description = "Ekskul Sepak Bola adalah tempat bagi para pecinta olahraga yang ingin mengembangkan keterampilan sepak bola mereka. Ekskul ini fokus pada pelatihan fisik dan teknik sepak bola, seperti dribbling, passing, shooting, dan taktik permainan. Selain itu, siswa juga akan belajar tentang disiplin, kerjasama tim, dan komunikasi di lapangan. Mereka berpartisipasi dalam latihan rutin di bawah bimbingan pelatih berpengalaman dan memiliki kesempatan untuk bermain dalam pertandingan antar sekolah atau turnamen lokal. Ekskul Sepak Bola membantu siswa mengembangkan keterampilan olahraga, kebugaran fisik, dan juga nilai-nilai penting seperti kerja sama tim, tanggung jawab, dan semangat persaingan yang sehat. Ini juga menjadi wadah untuk memupuk rasa cinta pada olahraga dan gaya hidup aktif yang sehat.",
                    Day = "Wednesday",
                    StartTime = TimeSpan.Parse("15:00:00"),
                    EndTime = TimeSpan.Parse("17:00:00"),
                    IconName = "sepak_bola"
                },
                new Ekskul
                {
                    Id = 2,
                    Name = "Musik",
                    Description = "Ekskul Musik adalah tempat di mana siswa dapat menggali potensi musik mereka. Selain mempelajari teori musik dan teknik bermain alat musik, siswa juga berpartisipasi dalam latihan ensemble untuk mengembangkan keterampilan bermain bersama. Mereka memiliki kesempatan untuk tampil dalam konser sekolah dan acara khusus.",
                    Day = "Thursday",
                    StartTime = TimeSpan.Parse("15:30:00"),
                    EndTime = TimeSpan.Parse("17:00:00"),
                    IconName = "musik"
                },
                new Ekskul
                {
                    Id = 3,
                    Name = "Basket",
                    Description = "Ekskul Olahraga Basket adalah tempat bagi para penggemar bola basket. Siswa tidak hanya memperbaiki keterampilan dasar seperti dribbling, passing, dan shooting, tetapi juga belajar taktik permainan yang lebih kompleks. Mereka berpartisipasi dalam latihan rutin, bertanding dalam turnamen antar sekolah, dan mungkin bahkan mengadakan klinis untuk pemain yang lebih muda.",
                    Day = "Monday",
                    StartTime = TimeSpan.Parse("16:00:00"),
                    EndTime = TimeSpan.Parse("18:00:00"),
                    IconName = "basket"
                },
                new Ekskul
                {
                    Id = 4,
                    Name = "Seni Lukis",
                    Description = "Ekskul Seni Lukis adalah tempat di mana siswa dapat mengekspresikan diri mereka melalui seni visual. Mereka memahami berbagai teknik lukisan, seperti akrilik, minyak, atau air, dan menciptakan karya seni mereka sendiri. Selain itu, mereka berkesempatan untuk berpartisipasi dalam pameran seni sekolah yang dapat menginspirasi dan mempromosikan bakat seni mereka.",
                    Day = "Wednesday",
                    StartTime = TimeSpan.Parse("16:30:00"),
                    EndTime = TimeSpan.Parse("18:30:00"),
                    IconName = "seni_lukis"
                },
                new Ekskul
                {
                    Id = 5,
                    Name = "Robotika",
                    Description = "Ekskul Robotika memadukan teknologi dan kreativitas. Siswa akan mempelajari dasar-dasar pemrograman dan mekanik, membangun robot, dan menghadapi berbagai tantangan teknis. Mereka juga dapat bergabung dalam tim kompetisi robotika di tingkat lokal atau nasional.",
                    Day = "Saturday",
                    StartTime = TimeSpan.Parse("14:00:00"),
                    EndTime = TimeSpan.Parse("16:00:00"),
                    IconName = "robotika"
                },
                new Ekskul
                {
                    Id = 6,
                    Name = "Jurnalistik",
                    Description = "Ekskul Jurnalistik mengembangkan kemampuan menulis dan kecakapan penyuntingan siswa. Mereka dapat membuat berita dan laporan tentang berbagai kegiatan sekolah, serta menghasilkan publikasi seperti surat kabar atau situs web sekolah. Ekskul ini membantu siswa mengasah kemampuan komunikasi dan pemahaman berita.",
                    Day = "Sunday",
                    StartTime = TimeSpan.Parse("17:00:00"),
                    EndTime = TimeSpan.Parse("19:00:00"),
                    IconName = "jurnalistik"
                },
                new Ekskul
                {
                    Id = 7,
                    Name = "Teater",
                    Description = "Ekskul Teater menghidupkan seni teater dengan latihan akting, menyutradarai, dan produksi pertunjukan. Siswa belajar menghayati peran, memahami naskah, dan bekerja sama dalam tim untuk menciptakan pertunjukan yang menghibur. Mereka juga terlibat dalam aspek-aspek produksi seperti kostum, dekorasi, dan pencahayaan.",
                    Day = "Friday",
                    StartTime = TimeSpan.Parse("18:30:00"),
                    EndTime = TimeSpan.Parse("20:30:00"),
                    IconName = "teater"
                },
                new Ekskul
                {
                    Id = 8,
                    Name = "Kewirausahaan",
                    Description = "Ekskul Kewirausahaan memberikan wawasan tentang dunia bisnis kepada siswa. Mereka dapat mengembangkan ide bisnis, merancang rencana bisnis, memahami manajemen keuangan, dan mungkin bahkan menjalankan bisnis kecil di sekolah sebagai pengalaman praktis.",
                    Day = "Tuesday",
                    StartTime = TimeSpan.Parse("17:30:00"),
                    EndTime = TimeSpan.Parse("19:00:00"),
                    IconName = "kewirausahaan"
                },
                new Ekskul
                {
                    Id = 9,
                    Name = "Lingkungan Hidup",
                    Description = "Ekskul Lingkungan Hidup bertujuan untuk menciptakan kesadaran tentang isu-isu lingkungan dan keberlanjutan. Siswa terlibat dalam berbagai kegiatan, termasuk penanaman pohon, pembersihan lingkungan, kampanye pengurangan sampah plastik, dan kunjungan ke area alam terbuka untuk memahami ekosistem lokal.",
                    Day = "Thursday",
                    StartTime = TimeSpan.Parse("16:00:00"),
                    EndTime = TimeSpan.Parse("18:00:00"),
                    IconName = "lingkungan_hidup"
                },
                new Ekskul
                {
                    Id = 10,
                    Name = "Komputer dan Pemrograman",
                    Description = "Ekskul Komputer dan Pemrograman memperkenalkan siswa pada dunia teknologi. Mereka belajar bahasa pemrograman, merancang aplikasi komputer atau permainan, dan mungkin berpartisipasi dalam kompetisi pemrograman seperti Olimpiade Komputer.",
                    Day = "Wednesday",
                    StartTime = TimeSpan.Parse("15:45:00"),
                    EndTime = TimeSpan.Parse("17:45:00"),
                    IconName = "komputer_dan_pemrograman"
                },
                new Ekskul
                {
                    Id = 11,
                    Name = "Debat dan Pidato",
                    Description = "Ekskul Debat dan Pidato adalah tempat siswa mengasah kemampuan berbicara dan berargumen. Mereka belajar teknik berbicara di depan umum, merancang argumen yang kuat, dan berpartisipasi dalam debat formal atau kompetisi pidato.",
                    Day = "Saturday",
                    StartTime = TimeSpan.Parse("16:15:00"),
                    EndTime = TimeSpan.Parse("18:15:00"),
                    IconName = "debat_dan_pidato"
                }
            };


            List<EkskulMember> ekskulMemberList = new List<EkskulMember>
            {
                new EkskulMember { Id = 1, UserId = 1, EkskulId = 1, Position = "Leader", JoinDate = DateTime.Parse("2023-09-14") },
                new EkskulMember { Id = 2, UserId = 2, EkskulId = 1, Position = "Member", JoinDate = DateTime.Parse("2023-09-15") },
                new EkskulMember { Id = 3, UserId = 3, EkskulId = 1, Position = "Member", JoinDate = DateTime.Parse("2023-09-16") },
                new EkskulMember { Id = 4, UserId = 4, EkskulId = 2, Position = "Leader", JoinDate = DateTime.Parse("2023-09-17") },
                new EkskulMember { Id = 5, UserId = 5, EkskulId = 2, Position = "Member", JoinDate = DateTime.Parse("2023-09-18") },
                new EkskulMember { Id = 6, UserId = 6, EkskulId = 2, Position = "Member", JoinDate = DateTime.Parse("2023-09-19") },
                new EkskulMember { Id = 7, UserId = 7, EkskulId = 3, Position = "Leader", JoinDate = DateTime.Parse("2023-09-20") },
                new EkskulMember { Id = 8, UserId = 8, EkskulId = 3, Position = "Member", JoinDate = DateTime.Parse("2023-09-21") },
                new EkskulMember { Id = 9, UserId = 9, EkskulId = 3, Position = "Member", JoinDate = DateTime.Parse("2023-09-22") },
                new EkskulMember { Id = 10, UserId = 10, EkskulId = 4, Position = "Leader", JoinDate = DateTime.Parse("2023-09-23") },
                new EkskulMember { Id = 11, UserId = 11, EkskulId = 4, Position = "Member", JoinDate = DateTime.Parse("2023-09-24") },
                new EkskulMember { Id = 12, UserId = 12, EkskulId = 4, Position = "Member", JoinDate = DateTime.Parse("2023-09-25") },
                new EkskulMember { Id = 13, UserId = 13, EkskulId = 5, Position = "Leader", JoinDate = DateTime.Parse("2023-09-26") },
                new EkskulMember { Id = 14, UserId = 14, EkskulId = 5, Position = "Member", JoinDate = DateTime.Parse("2023-09-27") },
                new EkskulMember { Id = 15, UserId = 15, EkskulId = 5, Position = "Member", JoinDate = DateTime.Parse("2023-09-28") },
                new EkskulMember { Id = 16, UserId = 16, EkskulId = 6, Position = "Leader", JoinDate = DateTime.Parse("2023-09-29") },
                new EkskulMember { Id = 17, UserId = 17, EkskulId = 6, Position = "Member", JoinDate = DateTime.Parse("2023-09-30") },
                new EkskulMember { Id = 18, UserId = 18, EkskulId = 6, Position = "Member", JoinDate = DateTime.Parse("2023-10-01") },
                new EkskulMember { Id = 19, UserId = 19, EkskulId = 7, Position = "Leader", JoinDate = DateTime.Parse("2023-10-02") },
                new EkskulMember { Id = 20, UserId = 20, EkskulId = 7, Position = "Member", JoinDate = DateTime.Parse("2023-10-03") },
                new EkskulMember { Id = 21, UserId = 21, EkskulId = 7, Position = "Member", JoinDate = DateTime.Parse("2023-10-04") },
                new EkskulMember { Id = 22, UserId = 22, EkskulId = 8, Position = "Leader", JoinDate = DateTime.Parse("2023-10-05") },
                new EkskulMember { Id = 23, UserId = 23, EkskulId = 8, Position = "Member", JoinDate = DateTime.Parse("2023-10-06") },
                new EkskulMember { Id = 24, UserId = 24, EkskulId = 8, Position = "Member", JoinDate = DateTime.Parse("2023-10-07") },
                new EkskulMember { Id = 25, UserId = 25, EkskulId = 9, Position = "Leader", JoinDate = DateTime.Parse("2023-10-08") },
                new EkskulMember { Id = 26, UserId = 26, EkskulId = 9, Position = "Member", JoinDate = DateTime.Parse("2023-10-09") },
                new EkskulMember { Id = 27, UserId = 27, EkskulId = 9, Position = "Member", JoinDate = DateTime.Parse("2023-10-10") },
                new EkskulMember { Id = 28, UserId = 28, EkskulId = 10, Position = "Leader", JoinDate = DateTime.Parse("2023-10-11") },
                new EkskulMember { Id = 29, UserId = 29, EkskulId = 10, Position = "Member", JoinDate = DateTime.Parse("2023-10-12") },
                new EkskulMember { Id = 30, UserId = 30, EkskulId = 10, Position = "Member", JoinDate = DateTime.Parse("2023-10-13") },
                new EkskulMember { Id = 31, UserId = 31, EkskulId = 11, Position = "Leader", JoinDate = DateTime.Parse("2023-10-14") },
                new EkskulMember { Id = 32, UserId = 32, EkskulId = 11, Position = "Member", JoinDate = DateTime.Parse("2023-10-15") },
                new EkskulMember { Id = 33, UserId = 33, EkskulId = 11, Position = "Member", JoinDate = DateTime.Parse("2023-10-16") }
            };

            db.Users.AddRange(userList);
            db.Ekskuls.AddRange(ekskulList);
            db.EkskulMembers.AddRange(ekskulMemberList);

            db.SaveChanges();
        }
    }
}
