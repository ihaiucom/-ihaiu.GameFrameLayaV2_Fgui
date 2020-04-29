using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DetectCharUtil
{
    //含有非法字符则返回true
    public static bool DetectChar(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 'a' && str[i] <= 'z')
            {
            }
            else if (str[i] >= 'A' && str[i] <= 'Z')
            {
            }
            else if (str[i] >= 0x4e00 && str[i] <= 0x9fbb)
            {
            }
            else if (str[i] >= '0' && str[i] <= '9')
            {
            }
            else if (IsLegalChar(str[i]))
            {
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    //是否为合法字符中的一个
    private static bool IsLegalChar(char c)
    {
        if (legalChars.Contains(c.ToString()))
            return true;//是合法字符
        return false;
    }

    private static string legalChars = " ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫㄱㄲㄳㄴㄵㄶㄷㄸㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅃㅄㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅥㅦㅧㅨㅩㅪㅫㅬㅭㅮㅯㅰㅱㅲㅳㅴㅵㅶㅷㅸㅹㅺㅻㅼㅽㅾㅿㆀㆁㆂㆃㆄㆅㆆㆇㆈㆉㆊぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔゕゖ゚゛゜ゝゞゟ゠ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶヷヸヹヺ・ーヽヾヿ√♡♢♀♂★☆↖↗↘↙↓←→↑％＋－／＝∧∠∩∪°≡≥∞∫≤≠∨‰π±√∑∴×αβγ︰:！＃＄％＆＊，．：；？＠～•、。…〈〈〉《》「」『』【】〔〕︵︶︷︸︹︺︻︼︽︽︾︿﹀﹁﹁﹂﹃﹄﹙﹙﹚﹛﹜﹝﹞﹤﹥（）＜＞｛｛｝";
}
