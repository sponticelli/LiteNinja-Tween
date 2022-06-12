# LiteNinja Tween
A task-based Tween library for Unity3D.

Tweening is an interpolation between 2 values using easing functions or Animation Curves.

### Simple Examples
Linear interpolation from 1 to 100 in 5 seconds:
```cs
var tween = new Tween();
await tween.Start(Easing.Linear, 0f, 100f, 5f,
                (v) => { Debug.Log(v); }, Mathf.Lerp, () => { Debug.Log("Tween completed"); },
                _cancellationTokenSource.Token);
```

Sine In interpolation from 1 to 100 in 5 seconds:
```cs
var tween = new Tween();
await tween.Start(Easing.SineIn, 0f, 100f, 5f,
                (v) => { Debug.Log(v); }, Mathf.Lerp, () => { Debug.Log("Tween completed"); },
                _cancellationTokenSource.Token);
```

It's possible to use an Animation Curve instead of an easing function:
```cs

```

### Extensions
LiteNinja Tween provides some extensions to tween objects.

```cs
var to = Vector3.one * Random.Range(1f, 5f);
await transform.TweenScale(to, 1.5f, Easing.ElasticIn, cancellationToken: _cancellationTokenSource.Token);
```


### Run Parallel Tweens
Being implemented using async/await, it is possible to run several tweens at the same time and wait for they are all completed.
```cs
var duration = 0.5f;
var t1 = transform.TweenScale(2f * Vector3.one, duration, Easing.BackIn);
var t2 = transform.TweenRotate(Quaternion.AngleAxis(90, Vector3.up), duration, Easing.CircOut);
await Task.WhenAll(t1, t2);
```

### Run Sequential Tweens
It's possible to chain tweens by awaiting them.
```cs
var duration = 0.5f;
await transform.TweenScale(2f * Vector3.one, duration, Easing.BackIn);
await transform.TweenRotate(Quaternion.AngleAxis(90, Vector3.up), duration, Easing.CircOut);
```

### Cancel a tween
```cs
var t = new Tween();
t.Start(...);
t.Cancel();
```

### ITimer
If not specified in the Tween ctor, Time.time it is used to run the tween (UnityTimer class). Other ready-to-use implementations are FixedTimer and UnscaledTimer.
You can also write your implementation of the ITimer interface.

### Demo Project
A demo Unity project can be found in the [demo branch](https://github.com/sponticelli/LiteTween/tree/demo)
