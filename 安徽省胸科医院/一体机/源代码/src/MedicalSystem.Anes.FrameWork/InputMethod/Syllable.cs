using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public class Syllable
    {
        //一个字的CN最前边那一个或两个是声母,后面的是韵母.声母有b p m f d t n l g k h j q x zh ch sh r z c s y w
        //韵母有a o e i u ü ai ei ui ao ou iu ie üe er an en in un ün ang eng ing ong
        //这些可以单独拼成字,也是韵母zhi chi shi ri zi ci si yi wu yu ye yue yuan yin yun ying
        //'bu'pei'zhi 不配置

        //声母共有23个。它们是b、p、m、f、d、t、n、l、g、k、h、j、q、x、zh、ch、sh、z、c、s 、 y、w、r。 
        //韵母24个。 单韵母是a、o、e、i、u、v。
        //复韵母是ai 、ei、 ui 、ao、 ou、 iu 、ie 、ve、 er、 an 、en 、in、 un 、vn 、ang 、eng、 ing 、ong 
        //整体认读音节在小学语文课本里，共安排16个，它们是：zhi 、chi 、shi 、ri 、zi 、ci 、si 、yi 、wu 、yu 、ye 、yue 、yin 、yun 、yuan 、ying 。
        //前鼻音韵母 an 、en 、in、 un 、vn
        //后鼻音韵母 ang 、eng、 ing 、ong

        //音节组合列表，本来想用二叉树完成但是发现实现起来相对麻烦，出问题又不会修改所以改用这种方式处理
        //nü->nv lü->lv
        //lüe->lue nüe->nue
        public static string[] YinJieArr = new string[]{ 
            "a","ai","an","ang","ao",
            "ba","bai","ban","bang","bao","bei","ben","beng","bi","bian","biao","bie","bin","bing","bo","bu",
            "ca","cai","can","cang","cao","ce","cen","ceng","cha","chai","chan","chang","chao","che","chen","cheng","chong","chou","chu","chua","chuai","chuan","chuang","chui","chun","chuo","cong","cou","cu","cuan","cui","cun","cuo",
            "da","dai","dan","dang","dao","de","dei","den","deng","di","dian","diao","die","ding","diu","dong","dou","du","duan","dui","dun","duo",
            "e","ei","en","eng","er","fa","fan","fang","fei","fen","feng","fo","fou","fu",
            "ga","gai","gan","gang","gao","ge","gei","gen","geng","gong","gou","gu","gua","guai","guan","guang","gui","gun","guo",
            "ha","hai","han","hang","hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan","huang","hui","hun","huo",
            "ji","jia","jian","jiang","jiao","jie","jin","jing","jiong","jiu","ju","juan","jue","jun",
            "ka","kai","kan","kang","kao","ke","ken","keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo",
            "la","lai","lan","lang","lao","le","lei","leng","li","lia","lian","liang","liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun","luo","ma","mai","man","mang","mao","me","mei","men","meng","mi","mian","miao","mie","min","ming","miu","mo","mou","mu",
            "na","nai","nan","nang","nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning","niu","nong","nou","nu","nv","nuan","nue","nuo",
            "o","ou","pa","pai","pan","pang","pao","pei","pen","peng","pi","pian","piao","pie","pin","ping","po","pou","pu",
            "qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan","que","qun",
            "ran","rang","rao","re","ren","reng","ri","rong","rou","ru","ruan","rui","run","ruo",
            "sa","sai","san","sang","sao","se","sen","seng","sha","shai","shan","shang","shao","she","shei","shen","sheng","shou","shu","shua","shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan","sui","sun","suo",
            "ta","tai","tan","tang","tao","te","teng","ti","tian","tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo",
            "wa","wai","wan","wang","wei","wen","weng","wo","wu",
            "xi","xia","xian","xiang","xiao","xie","xin","xing","xiong","xiu","xu","xuan","xue","xun",
            "ya","yan","yang","yao","ye","yi","yin","ying","yong","you","yu","yuan","yue","yun",
            "za","zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan","zhang","zhao","zhe","zhei","zhen","zheng","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang","zhui","zhun","zhuo","zong","zou","zu","zuan","zui","zun","zuo"
        };

        /// <summary>
        /// 声母
        /// </summary>
        public static string[] ShenMu = new string[] { "b", "p", "m", "f", "d", "t", "n", "l", "g", "k", "h", "j", "q", "x", "zh", "ch", "sh", "r", "z", "c", "s", "y", "w" };
        //string[] YunMu = new string[] { "a", "o", "e", "i", "u", "ü", "ai", "ei", "ui", "ao", "ou", "iu", "ie", "üe", "er", "an", "en", "in", "un", "ün", "ang", "eng", "ing", "ong" };
        /// <summary>
        /// 韵母单个字
        /// </summary>
        public static string[] YunMuZi = new string[] { "zhi", "chi", "shi", "ri", "zi", "ci", "si", "yi", "wu", "yu", "ye", "yue", "yuan", "yin", "yun", "ying" };

        public static string[] FuStrArr = new string[10]{
           ",·。！()【】〖〗＠：/\"_<>`≈{}~～_-『』√$@*&#※",
           "－×÷＋－±／＝∫∮∝∞∧∨∑∏‖∠≌∽≤≥≈＜＞じ",
            "☆↑↓⊙●★☆■♀『』◆◣◥▲Ψ ※◤◥ →№←㊣∑⌒〖〗＠",
           "⊙●○①♁◎Θ⊙¤㊣★☆♀◆◇◣◢◥▲▼△▽⊿◤◥",
            "▆▇██■▓回□〓≡╝╚╔╗╬═╓╩┠┨┯┷┏",
           "┓┗┛┳⊥『』┌┐└┘∟「」↑↓→←↘↙♀♂┇┅﹉﹊﹍﹎╭",
            "╮╰╯*^_-^∵∴‖｜︴﹏﹋﹌（）〔〕",
             "卐々∞Ψ∪∩∈∏の℡ぁ§∮”〃ミ灬ξ№∑⌒ξζω＊ㄨ≮≯＋",
           "ξζω□∮〓※∴ぷ▂▃▅▆█∏卐【】△√∩¤々♀♂∞①ㄨ≡↘↙▂",
             "▂▃▄▅▆▇█┗┛╰☆╮≠▂▃▄▅"};
    }
}
