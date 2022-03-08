struct Path
{
    int type;
    float s0;
    float s1;
    float e0;
    float e1;
    float p2;
    float p3;
    float p4;
    float p5;
};

struct Character
{
    int charAscii;
    int x_size_min;
    int x_size_max;
    int y_size_min;
    int y_size_max;
    Path paths[4];
};

struct CharacterData
{
    float fontSize;
    vec3 baseX;
    vec3 baseY;
    vec3 baseZ;
    vec3 pos;
};


// TODO: line -|- line crossing
int lineToLineCrossingPoints(vec3 l1Start, vec3 l1End, vec3 l2Start, vec3 l2End)
{
    return 0;
}
// TODO: line -|- qubicqurve crossing
// TODO: line -|- bazier qurve crossing



void setCharacterData(Character character)
{
    for(int i=0;i<100;++i)
    {
        Path path = character.paths[i];

        //mat4 matrix = 

        //path.start = vec3() * 

        character.paths[i] = path;
    }
}

bool includedInCharacter(vec3 vec, Character character, CharacterData data)
{
    return true;
}

varying vec3 vUv;

void main() {

    if(abs(vUv.x) < 0.03 && abs(vUv.y) < 0.03 && abs(vUv.z) < 0.03) {
        gl_FragColor = vec4(1, 1, 1, 1);
    } else{
        gl_FragColor = vec4(0, 0, 0, 0.3);
    }
}