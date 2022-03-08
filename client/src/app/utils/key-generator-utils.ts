export class KeyGeneratorUtils 
{
    public static instance: KeyGeneratorUtils = new KeyGeneratorUtils();

    public generateKey(): string
    {
        return 'xxxxxxxx-xxxx-xxxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random() * 16 | 0,
            v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}