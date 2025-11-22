M={'A':'.-','B':'-...','C':'-.-.','D':'-..','E':'.','F':'..-.','G':'--.','H':'....','I':'..','J':'.---','K':'-.-','L':'.-..',
   'M':'--','N':'-.','O':'---','P':'.--.','Q':'--.-','R':'.-.','S':'...','T':'-','U':'..-','V':'...-','W':'.--','X':'-..-',
   'Y':'-.--','Z':'--..','0':'-----','1':'.----','2':'..---','3':'...--','4':'....-','5':'.....','6':'-....','7':'--...',
   '8':'---..','9':'----.',',':'--..--','.':'.-.-.-','?':'..--..','/':'-..-.','-':'-....-','(':'-.--.',')':'-.--.-'}
e=lambda m:'  '.join(' '.join(M[c] for c in m)for w in m.upper().split())
d=lambda m:' '.join(''.join({v:k for k,v in M.items()}[c]for c in w.split())for w in m.split('  '))
s=lambda o,m:o=='encode'and e(m)or o=='decode'and d(m)or exec('raise ValueError("Invalid operation")')
def main():
    try:o,m=input("Enter operation (encode/decode): ").lower().strip(),input("Enter message: " ).strip();print(f"Result: {s(o,m)}")
    except KeyError:print("Error: Invalid character")
    except Exception as e:print(e)
if __name__ == '__main__':main()