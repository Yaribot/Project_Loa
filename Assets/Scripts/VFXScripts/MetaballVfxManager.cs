using UnityEngine;
using UnityEngine.VFX;

public class MetaballVfxManager : MonoBehaviour
{
    //private VisualEffect _visualEffect;
    private ParticleSystem _particleSystem;
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    private const int _maxParticles = 256;
    private int _numParticles;

    //private VisualEffectObject[] _particles = new VisualEffectObject[_maxParticles];
    private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[_maxParticles];
    private readonly Vector4[] _particlesPos = new Vector4[_maxParticles];
    private readonly float[] _particlesSize = new float[_maxParticles];

    static readonly int NumParticles = Shader.PropertyToID("_NumParticles");
    static readonly int ParticlesSize = Shader.PropertyToID("_ParticlesSize");
    static readonly int ParticlesPos = Shader.PropertyToID("_ParticlesPos");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SendParticlesPositionAndSizeToTheShader();
    }

    private void OnEnable()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _materialPropertyBlock = new MaterialPropertyBlock();
        _renderer = _particleSystem.GetComponent<Renderer>();
    }
    private void OnDisable()
    {
        _materialPropertyBlock.Clear();
        _materialPropertyBlock = null;
        _renderer.SetPropertyBlock(null);
    }

    private void SendParticlesPositionAndSizeToTheShader()
    {
        _numParticles = _particleSystem.particleCount;
        _particleSystem.GetParticles(_particles, _maxParticles);

        int i = 0;
        foreach (var particle in _particles)
        {
            _particlesPos[i] = particle.position;
            _particlesSize[i] = particle.GetCurrentSize(_particleSystem);
            ++i;

            if (i >= _numParticles) break;
        }

        _materialPropertyBlock.SetVectorArray(ParticlesPos, _particlesPos);
        _materialPropertyBlock.SetFloatArray(ParticlesSize, _particlesSize);
        _materialPropertyBlock.SetInt(NumParticles, _numParticles);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }
}
