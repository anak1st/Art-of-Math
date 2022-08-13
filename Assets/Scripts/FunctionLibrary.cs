using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary {
    public static Vector3 Wave(Vector3 vi, float t) {
        Vector3 vo = vi;
        vo.y = Sin(PI * (vi.x + vi.z + t)) / 1.25f;
        return vo;
    }

    public static Vector3 MultiWave(Vector3 vi, float t) {
        Vector3 vo = vi;
        vo.y = (Sin(PI * (vi.x + 0.5f * t)) + 0.5f * Sin(2f * PI * (vi.z + t))) / 2f;
        return vo;
    }

    public static Vector3 Ripple(Vector3 vi, float t) {
        Vector3 vo = vi;
        float d = Sqrt(vi.x * vi.x + vi.z * vi.z);
        vo.y = Sin(PI * (4f * d - t)) / (1f + 10f * d);
        return vo;
    }

    public static Vector3 Sphere(Vector3 vi, float t) {
        Vector3 vo;
        float r = (9f + Sin(PI * (6f * vi.x + 4f * vi.z + t))) / 10f;
        float s = Cos(0.5f * PI * vi.z);
        vo.x = s * Sin(PI * vi.x);
        vo.y = Sin(0.5f * PI * vi.z);
        vo.z = s * Cos(PI * vi.x);
        vo *= r;
        return vo;
    }

    public static Vector3 Torus(Vector3 vi, float t) {
        Vector3 vo;
        float r1 = (7f + Sin(PI * (6f * vi.x + 0.5f * t))) / 10f;
        float r2 = (3f + Sin(PI * (8f * vi.x + 4f * vi.z + 2f * t))) / 20f;
        float s = r1 + r2 * Cos(PI * vi.z);
        vo.x = s * Sin(PI * vi.x);
        vo.y = r2 * Sin(PI * vi.z);
        vo.z = s * Cos(PI * vi.x);
        vo *= 1.25f;
        return vo;
    }

    public delegate Vector3 Function(Vector3 vo, float t);

    public enum FunctionName {
        Wave,
        MultiWave,
        Ripple,
        Sphere,
        Torus
    }

    private static Function[] Functions = {
        Wave,
        MultiWave,
        Ripple,
        Sphere,
        Torus
    };

    public static Function GetFunction(FunctionName functionName) {
        return Functions[(int)functionName];
    }
}