uniform vec3 colorA; 
uniform vec3 colorB; 
uniform float size; 
uniform float split;
varying vec3 vUv;



bool isVectorNear(vec3 vec, float modulo, float epsilon)
{
    if(!(abs(mod(vec.x, modulo)) <= epsilon || abs(abs(mod(vec.x, modulo))-modulo) <= epsilon))
        return false;

    if(!(abs(mod(vec.y, modulo)) <= epsilon || abs(abs(mod(vec.y, modulo))-modulo) <= epsilon))
        return false;

    if(!(abs(mod(vec.z, modulo)) <= epsilon || abs(abs(mod(vec.z, modulo))-modulo) <= epsilon))
        return false;

    return true;
}

void main() {    
    float thickness = split * 0.02;
    float halfThickness = thickness / 2.0;
    float quartThickness = thickness / 4.0;
    float fifthSplit = split / 5.0;
    float border = (size / 2.0) - thickness;


    if(abs(vUv.x) > border || abs(vUv.y) > border || abs(vUv.z) > border) {
        gl_FragColor = vec4(1, 1, 1, 1);
    } else if(abs(vUv.x) < thickness && abs(vUv.y) < thickness && abs(vUv.z) < thickness) {
        gl_FragColor = vec4(1, 1, 1, 1);
    } else if(isVectorNear(vUv, split, halfThickness)) {
        gl_FragColor = vec4(1, 1, 1, 0.7);
    } else if(isVectorNear(vUv, fifthSplit, quartThickness)) {
        gl_FragColor = vec4(1, 1, 1, 0.4);
    } else{
        gl_FragColor = vec4(0, 0, 0, 0.1);
    }
    //gl_FragColor = vec4(1, 1, 1, 1);
}